using Dal;
using Entities;
using System.Runtime;

namespace CarRentalApp.Services
{
    public class ServiceBus : IBusService
    {

        public async Task CreateAsync(EntBus bus)
        {
            await DalBus.CreateAsync(bus);
        }

        public async Task<List<EntBus>> GetAllAsync()
        {
            return await DalBus.GetAllAsync();
        }

        public async Task<EntBus> GetByIdAsync(string id) =>
            await DalBus.GetByIdAsync(id);

        public async Task UpdateAsync(string id, EntBus bus) =>
            await DalBus.UpdateAsync(id, bus);

        public async Task DeleteAsync(string id) =>
            await DalBus.DeleteAsync(id);

        public async Task<List<EntBus>> GetAllByIdAsync(string BusinessId)
        {
            return await DalBus.GetAllByIdAsync(BusinessId);
        }
    }
}
