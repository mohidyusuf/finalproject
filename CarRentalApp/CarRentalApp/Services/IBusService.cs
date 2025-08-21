using Entities;

namespace CarRentalApp.Services
{
    public interface IBusService
    {
        Task CreateAsync(EntBus bus);
        Task<EntBus> GetByIdAsync(string id);
        Task UpdateAsync(string id, EntBus bus);
        Task DeleteAsync(string id);
        Task<List<EntBus>> GetAllByIdAsync(string BusinessId);
    }
}
