using Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class DalCar
    {
        private static readonly IMongoCollection<EntCar> _car;
        private static readonly IMongoCollection<EntCarPackage> _packages;

        static DalCar()
        {
            var client = new MongoClient(DbRegistration.ConnectionString);
            var database = client.GetDatabase(DbRegistration.DatabaseName);
            _car = database.GetCollection<EntCar>(DbRegistration.CarCollection);
            _packages = database.GetCollection<EntCarPackage>(DbRegistration.CarPackageCollection);
        }

        public static async Task CreateAsync(EntCar car) =>
          await _car.InsertOneAsync(car);

        public static async Task<List<EntCar>> GetAllAsync() =>
           await _car.Find(_ => true).ToListAsync();

        public static async Task<EntCar> GetByIdAsync(string id) =>
    await _car.Find(x => x.Id == id).FirstOrDefaultAsync();

        public static async Task UpdateAsync(string id, EntCar car) =>
            await _car.ReplaceOneAsync(x => x.Id == id, car);

        public static async Task DeleteAsync(string id)
        {
            await _car.DeleteOneAsync(x => x.Id == id);
            await _packages.DeleteManyAsync(x => x.CarId == id);
        }


        public static async Task<List<EntCar>> GetAllByIdAsync(string BusinessId)
        {
            var list = await _car.Find(x => x.BusinessId == BusinessId).ToListAsync();
            return list ?? new List<EntCar>();
        }



    }

}
