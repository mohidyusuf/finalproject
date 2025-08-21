 using Entities;

namespace CarRentalApp.Services
{
    public interface IHiaceService
    {
        Task CreateAsync(EntHiace hiace);
        Task<List<EntHiace>> GetAllAsync();
        Task<EntHiace> GetByIdAsync(string id);
        Task UpdateAsync(string id, EntHiace hiace);
        Task DeleteAsync(string id);
        Task<List<EntHiace>> GetAllByIdAsync(string BusinessId); 
    }
}
