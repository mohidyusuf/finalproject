using Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class DalCarPackage
    {

        private static readonly IMongoCollection<EntCarPackage> _CarPackage;
        private static readonly IMongoCollection<EntAboutShowroom> _business;
        private static readonly IMongoCollection<EntCar> _car;

        static DalCarPackage()
        {
            var client = new MongoClient(DbRegistration.ConnectionString);
            var database = client.GetDatabase(DbRegistration.DatabaseName);
            _CarPackage = database.GetCollection<EntCarPackage>(DbRegistration.CarPackageCollection);
            _business = database.GetCollection<EntAboutShowroom>(DbRegistration.AboutCollection);
            _car = database.GetCollection<EntCar>(DbRegistration.CarCollection);
        }

        public static async Task CreateAsync(EntCarPackage Cp) =>
            await _CarPackage.InsertOneAsync(Cp);

        public static async Task<List<EntCarPackage>> GetAllAsync() =>
       (await _CarPackage.Find(_ => true).ToListAsync())
           .Where(pkg => _business.Find(x => x.Id == pkg.BusinessId && x.Status == true).Any())
           .ToList();


        public static async Task DeleteAsync(string id) =>
           await _CarPackage.DeleteOneAsync(x => x.Id == id);

        public static async Task<List<EntCarPackage>> GetAllByBusinessIdAsync(string businessId)
        {
            EntAboutShowroom? business = _business.Find(x => x.Id == businessId && x.Status == true).FirstOrDefault() ?? null;
            if (business != null)
            {
                var pkgList = await _CarPackage.Find(x => x.BusinessId == businessId).ToListAsync();
                return pkgList;
            }
            return new List<EntCarPackage>();
        }


        public static  async Task<List<EntCarPackage>> SearchCarPackagesAsync(decimal? maxPrice, string duration)
        {
            var filter = Builders<EntCarPackage>.Filter.Empty;

            if (maxPrice.HasValue)
                filter &= Builders<EntCarPackage>.Filter.Lte(p => p.Price, maxPrice.Value);

            if (!string.IsNullOrEmpty(duration))
                filter &= Builders<EntCarPackage>.Filter.Eq(p => p.Duration, duration);

            return await _CarPackage.Find(filter).ToListAsync();
        }

        public static async Task<EntCarPackage?> GetByIdAsync(string id)
        {
            return await _CarPackage.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

    }
}
