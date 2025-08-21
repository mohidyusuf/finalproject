using Microsoft.AspNetCore.Components.Forms;

namespace CarRentalApp.Services
{
    public interface IImageUploadService
    {
        Task<string> UploadImageAsync(IBrowserFile file, string folder);
    }
}
