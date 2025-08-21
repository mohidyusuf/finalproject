using Dal;
using Entities;

namespace CarRentalApp.Services
{
    public class ServiceCarPackage : ICarPackageService
    {
        public async Task CreateAsync(EntCarPackage package)
        {
            await DalCarPackage.CreateAsync(package);
        }

        public async Task<List<EntCarPackage>> GetAllAsync()
        {
            return await DalCarPackage.GetAllAsync();
        }

        public async Task DeleteAsync(string id)
        {
            await DalCarPackage.DeleteAsync(id);
        }

        public async Task<List<EntCarPackage>> GetAllByBusinessIdAsync(string businessId)
        {
            return await DalCarPackage.GetAllByBusinessIdAsync(businessId);
        }



        public async Task<List<EntCarPackage>> SearchCarPackagesAsync(decimal? maxPrice, string duration)
        {
            return await DalCarPackage.SearchCarPackagesAsync(maxPrice, duration);
        }


        public async Task<EntCarPackage?> GetByIdAsync(string id)
        {
            return await DalCarPackage.GetByIdAsync(id);
        }
    }
}
