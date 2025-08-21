using Dal;
using Entities;

namespace CarRentalApp.Services
{
    public class ServiceHiacePackage : IHiacePackageService
    {
        public async Task CreateAsync(EntHiacePackage package)
        {
            await DalHiacePackage.CreateAsync(package);
        }

        public async Task<List<EntHiacePackage>> GetAllAsync()
        {
            return await DalHiacePackage.GetAllAsync();
        }


        public async Task DeleteAsync(string id)
        {
            await DalHiacePackage.DeleteAsync(id);
        }

        public async Task<List<EntHiacePackage>> GetAllByBusinessIdAsync(string businessId)
        {
            return await DalHiacePackage.GetAllByBusinessIdAsync(businessId);
        }

        public async Task<List<EntHiacePackage>> SearchHiacePackagesAsync(decimal? maxPrice, string duration)
        {
            return await DalHiacePackage.SearchHiacePackagesAsync(maxPrice, duration);
        }

        public async Task<EntHiacePackage?> GetByIdAsync(string id)
        {
            return await DalHiacePackage.GetByIdAsync(id);
        }
    }
}
