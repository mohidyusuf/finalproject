using Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class DalUser
    {
        private static readonly IMongoCollection<EntAppUser> _users;

        static DalUser()
        {
            var client = new MongoClient(DbRegistration.ConnectionString);
            var database = client.GetDatabase(DbRegistration.DatabaseName);
            _users = database.GetCollection<EntAppUser>(DbRegistration.UserCollection);
        }

        public static async Task<EntAppUser> GetUserByEmail(string email)
        {
            var user = await _users.Find(p => p.Email == email).FirstOrDefaultAsync();
            return user;
        }

        public static async Task<long> GetUserCount()
        {
            long count = await _users.CountDocumentsAsync(FilterDefinition<EntAppUser>.Empty);
            return count;
        }

        public static async Task AddUser(EntAppUser user)
        {
            await _users.InsertOneAsync(user);
        }
    }
}
