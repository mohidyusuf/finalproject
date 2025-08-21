using Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{

    public static class DalHiacePackage
    {

        private static readonly IMongoCollection<EntHiacePackage> _HiacePackage;
        private static readonly IMongoCollection<EntAboutShowroom> _business;


        static DalHiacePackage()
        {
            var client = new MongoClient(DbRegistration.ConnectionString);
            var database = client.GetDatabase(DbRegistration.DatabaseName);
            _HiacePackage = database.GetCollection<EntHiacePackage>(DbRegistration.HiacePackageCollection);
            _business = database.GetCollection<EntAboutShowroom>(DbRegistration.AboutCollection);
        }

        public static async Task CreateAsync(EntHiacePackage Cp) =>
            await _HiacePackage.InsertOneAsync(Cp);

        public static async Task<List<EntHiacePackage>> GetAllAsync() =>
        (await _HiacePackage.Find(_ => true).ToListAsync())
        .Where(pkg => _business.Find(x => x.Id == pkg.BusinessId && x.Status == true).Any())
        .ToList();

        public static async Task DeleteAsync(string id) =>
           await _HiacePackage.DeleteOneAsync(x => x.Id == id);

        public static async Task<List<EntHiacePackage>> GetAllByBusinessIdAsync(string businessId) =>
          (await _business.Find(x => x.Id == businessId && x.Status == true).FirstOrDefaultAsync()) != null
          ? await _HiacePackage.Find(x => x.BusinessId == businessId).ToListAsync()
          : new List<EntHiacePackage>();


        public static async Task<EntHiacePackage?> GetByIdAsync(string id)
        {
            return await _HiacePackage.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
        public static async Task<List<EntHiacePackage>> SearchHiacePackagesAsync(decimal? maxPrice, string duration)
        {
            var filter = Builders<EntHiacePackage>.Filter.Empty;

            if (maxPrice.HasValue)
                filter &= Builders<EntHiacePackage>.Filter.Lte(p => p.Price, maxPrice.Value);

            if (!string.IsNullOrEmpty(duration))
                filter &= Builders<EntHiacePackage>.Filter.Eq(p => p.Duration, duration);

            return await _HiacePackage.Find(filter).ToListAsync();
        }

    }
}

