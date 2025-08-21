using Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class DalBus
    {
        private static readonly IMongoCollection<EntBus> _bus;
        private static readonly IMongoCollection<EntBusPackage> _packages;
        static DalBus()
        {
            var client = new MongoClient(DbRegistration.ConnectionString);
            var database = client.GetDatabase(DbRegistration.DatabaseName);
            _bus = database.GetCollection<EntBus>(DbRegistration.BusCollection);
            _packages = database.GetCollection<EntBusPackage>(DbRegistration.BusPackageCollection);
        }

        public static async Task CreateAsync(EntBus bus) =>
          await _bus.InsertOneAsync(bus);

        public static async Task<List<EntBus>> GetAllAsync() =>
           await _bus.Find(_ => true).ToListAsync();


        public static async Task<EntBus> GetByIdAsync(string id) =>
    await _bus.Find(x => x.Id == id).FirstOrDefaultAsync();

        public static async Task UpdateAsync(string id, EntBus bus) =>
            await _bus.ReplaceOneAsync(x => x.Id == id, bus);

        public static async Task DeleteAsync(string id) 
        { 
            await _bus.DeleteOneAsync(x => x.Id == id);
        await _packages.DeleteManyAsync(x => x.BusId == id);
        }
        public static async Task<List<EntBus>> GetAllByIdAsync(string BusinessId)
        {
            var list = await _bus.Find(x => x.BusinessId == BusinessId).ToListAsync();
            return list ?? new List<EntBus>();
        }
    }
}