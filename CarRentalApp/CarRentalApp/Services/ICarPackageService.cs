using Entities;

namespace CarRentalApp.Services
{
    public interface ICarPackageService
    {

        Task CreateAsync(EntCarPackage package);
        Task<List<EntCarPackage>> GetAllAsync();
        Task<List<EntCarPackage>> GetAllByBusinessIdAsync(string businessId);
        Task DeleteAsync(string id);


        Task<List<EntCarPackage>> SearchCarPackagesAsync(decimal? maxPrice, string duration);
        Task<EntCarPackage?> GetByIdAsync(string id);

    }
}
