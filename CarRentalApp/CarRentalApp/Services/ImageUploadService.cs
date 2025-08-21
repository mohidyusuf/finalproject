using Microsoft.AspNetCore.Components.Forms;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing; // Add this for processing extensions

namespace CarRentalApp.Services
{
    public class ImageUploadService : IImageUploadService
    {
        private readonly IWebHostEnvironment _env;
        private const long MaxFileSize = 2 * 1024 * 1024; // 2MB

        public ImageUploadService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> UploadImageAsync(IBrowserFile file, string folder)
        {
            // Validate extension
            var extension = Path.GetExtension(file.Name).ToLower();
            if (!new[] { ".jpg", ".jpeg", ".png", ".gif", ".jfif","avif" }.Contains(extension))
                throw new InvalidOperationException("Only JPG, JPEG, PNG , jfif or GIF files allowed");

            // Process image
            await using var imageStream = await ProcessImageAsync(file);

            // Save to server
            var uploadPath = Path.Combine(_env.WebRootPath, folder);
            Directory.CreateDirectory(uploadPath);

            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadPath, fileName);

            await using var fileStream = new FileStream(filePath, FileMode.Create);
            await imageStream.CopyToAsync(fileStream);

            return $"/{folder}/{fileName}";
        }

        private async Task<Stream> ProcessImageAsync(IBrowserFile file)
        {
            // Load the image
            using var image = await Image.LoadAsync(file.OpenReadStream(MaxFileSize));
            var outputStream = new MemoryStream();

            // Save with quality adjustment if needed
            var encoder = new JpegEncoder { Quality = GetQualityForSize(image, MaxFileSize) };
            await image.SaveAsJpegAsync(outputStream, encoder);

            outputStream.Position = 0;
            return outputStream;
        }

        private int GetQualityForSize(Image image, long maxSize)
        {
            // Test quality levels to find optimal size
            for (int quality = 85; quality >= 30; quality -= 15)
            {
                var testStream = new MemoryStream();
                image.SaveAsJpeg(testStream, new JpegEncoder { Quality = quality });
                if (testStream.Length <= maxSize) return quality;
            }
            return 30; // Minimum quality
        }
    }
}