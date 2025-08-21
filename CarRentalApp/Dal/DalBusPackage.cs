using Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class DalBusPackage
    {

        private static readonly IMongoCollection<EntBusPackage> _BusPackage;
        private static readonly IMongoCollection<EntAboutShowroom> _business;

        static DalBusPackage()
        {
            var client = new MongoClient(DbRegistration.ConnectionString);
            var database = client.GetDatabase(DbRegistration.DatabaseName);
            _BusPackage = database.GetCollection<EntBusPackage>(DbRegistration.BusPackageCollection);
            _business = database.GetCollection<EntAboutShowroom>(DbRegistration.AboutCollection);
        }

        public static async Task CreateAsync(EntBusPackage Cp) =>
            await _BusPackage.InsertOneAsync(Cp);


        public static async Task<List<EntBusPackage>> GetAllAsync() =>
      (await _BusPackage.Find(_ => true).ToListAsync())
          .Where(pkg => _business.Find(x => x.Id == pkg.BusinessId && x.Status == true).Any())
          .ToList();



        public static async Task DeleteAsync(string id) =>
          await _BusPackage.DeleteOneAsync(x => x.Id == id);

        public static async Task<List<EntBusPackage>> GetAllByBusinessIdAsync(string businessId) =>
           (await _business.Find(x => x.Id == businessId && x.Status == true).FirstOrDefaultAsync()) != null
           ? await _BusPackage.Find(x => x.BusinessId == businessId).ToListAsync()
           : new List<EntBusPackage>();

        public static async Task<List<EntBusPackage>> SearchBusPackagesAsync(decimal? maxPrice, string duration)
        {
            var filter = Builders<EntBusPackage>.Filter.Empty;

            if (maxPrice.HasValue)
                filter &= Builders<EntBusPackage>.Filter.Lte(p => p.Price, maxPrice.Value);

            if (!string.IsNullOrEmpty(duration))
                filter &= Builders<EntBusPackage>.Filter.Eq(p => p.Duration, duration);

            return await _BusPackage.Find(filter).ToListAsync();
        }

        public static async Task<EntBusPackage?> GetByIdAsync(string id)
        {
            return await _BusPackage.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

    }
}

