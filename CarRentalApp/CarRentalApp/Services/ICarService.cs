using Entities;

namespace CarRentalApp.Services
{
    public interface ICarService
    {
        Task CreateAsync(EntCar car);
        Task<List<EntCar>> GetAllAsync();
        Task<EntCar> GetByIdAsync(string id);
        Task UpdateAsync(string id, EntCar car);
        Task DeleteAsync(string id);
        Task<List<EntCar>> GetAllByIdAsync(string BusinessId);
      
    }
}
