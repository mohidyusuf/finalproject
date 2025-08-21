using Dal;
using Entities;

namespace CarRentalApp.Services
{
    public class ServiceBusPackage : IBusPackageService
    {
        public async Task CreateAsync(EntBusPackage package)
        {
            await DalBusPackage.CreateAsync(package);
        }

        public async Task<List<EntBusPackage>> GetAllAsync()
        {
            return await DalBusPackage.GetAllAsync();
        }
        public async Task<List<EntBusPackage>> GetAllByBusinessIdAsync(string businessId)
        {
            return await DalBusPackage.GetAllByBusinessIdAsync(businessId);
        }
        public async Task DeleteAsync(string id)
        {
            await DalBusPackage.DeleteAsync(id);
        }

        public async Task<List<EntBusPackage>> SearchBusPackagesAsync(decimal? maxPrice, string duration)
        {
            return await DalBusPackage.SearchBusPackagesAsync(maxPrice, duration);
        }

        public async Task<EntBusPackage?> GetByIdAsync(string id)
        {
            return await DalBusPackage.GetByIdAsync(id);
        }
    }
}
