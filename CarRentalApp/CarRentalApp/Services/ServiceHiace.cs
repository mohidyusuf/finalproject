using Dal;
using Entities;
using System.Runtime;

namespace CarRentalApp.Services
{
    public class ServiceHiace : IHiaceService
    {
       
        public async Task CreateAsync(EntHiace hiace)
        {
         await   DalHiace.CreateAsync(hiace);
        }

        public async Task<List<EntHiace>> GetAllAsync()
        {
            return await DalHiace.GetAllAsync();
        }

        public async Task<EntHiace> GetByIdAsync(string id) =>
        await DalHiace.GetByIdAsync(id);

        public async Task UpdateAsync(string id, EntHiace hiace) =>
            await DalHiace.UpdateAsync(id, hiace);

        public async Task DeleteAsync(string id) =>
            await DalHiace.DeleteAsync(id);

        public async Task<List<EntHiace>> GetAllByIdAsync(string BusinessId)
        {
            return await DalHiace.GetAllByIdAsync(BusinessId);
        }

       
    }
}
