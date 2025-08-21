using Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class DalHiace
    {
        private static readonly IMongoCollection<EntHiace> _hiace;
        private static readonly IMongoCollection<EntHiacePackage> _packages;

       static DalHiace()
        {
            var client = new MongoClient(DbRegistration.ConnectionString);
            var database = client.GetDatabase(DbRegistration.DatabaseName);
            _hiace = database.GetCollection<EntHiace>(DbRegistration.HiaceCollection);
            _packages = database.GetCollection<EntHiacePackage>(DbRegistration.HiacePackageCollection);
        }

        public static async Task CreateAsync(EntHiace hiace) =>
          await _hiace.InsertOneAsync(hiace);

        public static async Task<List<EntHiace>> GetAllAsync() =>
           await _hiace.Find(_ => true).ToListAsync();

       



        public static async Task<EntHiace> GetByIdAsync(string id) =>
           await _hiace.Find(x => x.Id == id).FirstOrDefaultAsync();

        public static async Task UpdateAsync(string id, EntHiace hiace) =>
            await _hiace.ReplaceOneAsync(x => x.Id == id, hiace);

        public static   async Task DeleteAsync(string id) { 
            await _hiace.DeleteOneAsync(x => x.Id == id);
        await _packages.DeleteManyAsync(x => x.HiaceId == id);

        }
        public static async Task<List<EntHiace>> GetAllByIdAsync(string BusinessId)
        {
            var list = await _hiace.Find(x => x.BusinessId == BusinessId).ToListAsync();
            return list ?? new List<EntHiace>();
        }
    }
}
