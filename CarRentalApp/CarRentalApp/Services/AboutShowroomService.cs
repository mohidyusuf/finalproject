using Dal;
using Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalApp.Services
{
    public class AboutShowroomService : IAboutShowroomService
    {
        public async Task CreateAboutShowroom(EntAboutShowroom showroom)
        {
            await DalAboutShowroom.CreateAsync(showroom);
        }


        public async Task<List<EntAboutShowroom>> GetAllShowrooms()
        {
            return await DalAboutShowroom.GetAllAsync();
        }
        public async Task<EntAboutShowroom?> GetShowroomById(string id)
        {
            return await DalAboutShowroom.GetByIdAsync(id);
        }


        public async Task<EntAboutShowroom?> GetShowroomByUserId(string userId)
        {
            return await DalAboutShowroom.GetByUserIdAsync(userId);
        }

        public async Task UpdateShowroom(EntAboutShowroom updatedShowroom)
        {
            await DalAboutShowroom.UpdateAsync(updatedShowroom.Id, updatedShowroom);
        }

        public async Task<string> GetBusinessIdByUserId(string UserId)
        {
            return await DalAboutShowroom.GetBusinessIdByUserId(UserId);
        }

        public async Task UpdateCoverImage(EntCoverImage UpdateCoverIamge)
        {
            await DalAboutShowroom.UpdateCoverImageAsync(UpdateCoverIamge);
        }
        public async Task UpdateLogoImage(EntLogoImage UpdateLogoIamge)
        {
            await DalAboutShowroom.UpdateLogoImageAsync(UpdateLogoIamge);
        }

        public async Task<List<EntAboutShowroom>> GetShowroomsByCity(string city)
        {
            return await DalAboutShowroom.GetByCityAsync(city);
        }

        public async Task<bool> CheckBusinessExist(string UserId)
        {
            return await DalAboutShowroom.CheckBusinessExist(UserId);
        }


        public async Task<List<EntAboutShowroom>> GetRandomShowroomsAsync(int count = 3)
        {
            return await DalAboutShowroom.GetRandomShowroomsAsync(count);
        }


        public async Task<EntAboutShowroom?> GetShowroomByIdAsync(string id)
        {
            return await DalAboutShowroom.GetByIdAsync(id);
        }

        public async Task<EntAboutShowroom?> GetByBusinessId(string BusinessId)
        {
            return await DalAboutShowroom.GetByBusinessId(BusinessId);
        }
    }
}