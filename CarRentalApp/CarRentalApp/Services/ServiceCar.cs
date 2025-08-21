using Dal;
using Entities;
using System.Runtime;

namespace CarRentalApp.Services
{
    public class ServiceCar : ICarService
    {
        public async Task CreateAsync(EntCar car)
        {
            await DalCar.CreateAsync(car);
        }

        public async Task<List<EntCar>> GetAllAsync()
        {
            return await DalCar.GetAllAsync();
        }

        public async Task<EntCar> GetByIdAsync(string id)
        {
            return await DalCar.GetByIdAsync(id);
        }

        public async Task UpdateAsync(string id, EntCar car)
        {
            await DalCar.UpdateAsync(id, car);
        }

        public async Task DeleteAsync(string id)
        {
           
            await DalCar.DeleteAsync(id);
        }

        public async Task<List<EntCar>> GetAllByIdAsync(string BusinessId)
        {
            return await DalCar.GetAllByIdAsync(BusinessId);
        }


    }
}
