using Entities;

namespace CarRentalApp.Services
{
    public interface IHiacePackageService
    {
        Task CreateAsync(EntHiacePackage package);
        Task<List<EntHiacePackage>> GetAllAsync();
        Task<List<EntHiacePackage>> GetAllByBusinessIdAsync(string businessId);
        Task DeleteAsync(string id);

        Task<List<EntHiacePackage>> SearchHiacePackagesAsync(decimal? maxPrice, string duration);

        Task<EntHiacePackage?> GetByIdAsync(string id);
    }
}
