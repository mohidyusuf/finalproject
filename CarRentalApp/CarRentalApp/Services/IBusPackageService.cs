using Entities;

namespace CarRentalApp.Services
{
    public interface IBusPackageService
    {
        Task CreateAsync(EntBusPackage package);
        Task<List<EntBusPackage>> GetAllAsync();
        Task<List<EntBusPackage>> GetAllByBusinessIdAsync(string businessId);
        Task DeleteAsync(string id);

        Task<List<EntBusPackage>> SearchBusPackagesAsync(decimal? maxPrice, string duration);
        Task<EntBusPackage?> GetByIdAsync(string id);
    }
}
