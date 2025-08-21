using Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dal
{
    public static class DalAboutShowroom
    {
        private static readonly IMongoCollection<EntAboutShowroom> _aboutShowrooms;

        static DalAboutShowroom()
        {
            var client = new MongoClient(DbRegistration.ConnectionString);
            var database = client.GetDatabase(DbRegistration.DatabaseName);
            _aboutShowrooms = database.GetCollection<EntAboutShowroom>(DbRegistration.AboutCollection);
        }

        public static async Task CreateAsync(EntAboutShowroom showroom)
        {
            await _aboutShowrooms.InsertOneAsync(showroom);
        }

        public static async Task<List<EntAboutShowroom>> GetAllAsync()
        {
            return await _aboutShowrooms.Find(_ => true).ToListAsync();
        }

        /// <summary>
        /// Get showroom by database ObjectId
        /// </summary>
        public static async Task<EntAboutShowroom?> GetByIdAsync(string id)
        {
            return await _aboutShowrooms.Find(s => s.UserId == id).FirstOrDefaultAsync();
        }

        public static async Task<string> GetBusinessIdByUserId(string UserId)
        {
            var showroom = await _aboutShowrooms.Find(s => s.UserId == UserId).FirstOrDefaultAsync();
            return showroom?.Id ?? string.Empty; // Return empty string if no showroom found
        }

        public static async Task<bool> CheckBusinessExist(string UserId)
        {
            var exists = await _aboutShowrooms.Find(s => s.UserId == UserId).AnyAsync();
            return exists;
        }

        /// <summary>
        /// Get showroom by UserId (used for checking if the user already has a showroom)
        /// </summary>
        public static async Task<EntAboutShowroom?> GetByUserIdAsync(string userId)
        {
            return await _aboutShowrooms.Find(s => s.UserId == userId).FirstOrDefaultAsync();
        }
        public static async Task<EntAboutShowroom?> GetByBusinessId(string BusinessId)
        {
            return await _aboutShowrooms.Find(s => s.Id == BusinessId).FirstOrDefaultAsync();
        }

        public static async Task UpdateAsync(string id, EntAboutShowroom updatedShowroom)
        {
            await _aboutShowrooms.ReplaceOneAsync(s => s.Id == id, updatedShowroom);
        }
        public static async Task UpdateCoverImageAsync(EntCoverImage entCoverImage)
        {
            var filter = Builders<EntAboutShowroom>.Filter.Eq(s => s.Id, entCoverImage.Id);
            var update = Builders<EntAboutShowroom>.Update
                .Set(s => s.Cover, entCoverImage.CoverImageUrl);

            await _aboutShowrooms.UpdateOneAsync(filter, update);

        }


        public static async Task UpdateLogoImageAsync(EntLogoImage entLogoImage)
        {
            var filter = Builders<EntAboutShowroom>.Filter.Eq(s => s.Id, entLogoImage.Id);
            var update = Builders<EntAboutShowroom>.Update
                .Set(s => s.Logo, entLogoImage.LogoImageUrl);

            await _aboutShowrooms.UpdateOneAsync(filter, update);

        }


        public static async Task<List<EntAboutShowroom>> GetByCityAsync(string city)
        {
            var allShowrooms = await GetAllAsync();
            return allShowrooms.Where(s => !string.IsNullOrEmpty(s.City) && s.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
        }


        public static async Task<List<EntAboutShowroom>> GetRandomShowroomsAsync(int count = 3)
        {
            // Get total number of showrooms
            var totalCount = await _aboutShowrooms.CountDocumentsAsync(_ => true);

            // If fewer than requested, adjust
            var takeCount = (int)Math.Min(totalCount, count);

            if (takeCount == 0)
                return new List<EntAboutShowroom>();

            // Use MongoDB aggregation with $sample for random selection
            return await _aboutShowrooms.Aggregate().Sample(takeCount).ToListAsync();
        }
    }
}