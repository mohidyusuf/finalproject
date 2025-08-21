using Dal;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalApp.Services
{
    public interface IAboutShowroomService
    {
        Task CreateAboutShowroom(EntAboutShowroom showroom);
        Task<List<EntAboutShowroom>> GetAllShowrooms();

        /// <summary>
        /// Get showroom by its database ID
        /// </summary>
        Task<EntAboutShowroom?> GetShowroomById(string id);

        /// <summary>
        /// Get showroom by UserId (used to check if a user already created one)
        /// </summary>
        Task<EntAboutShowroom?> GetShowroomByUserId(string userId);
        Task UpdateShowroom(EntAboutShowroom updatedShowroom);
        Task UpdateCoverImage(EntCoverImage UpdateCoverIamge);
        Task UpdateLogoImage(EntLogoImage UpdateLogoIamge);
        Task<string> GetBusinessIdByUserId(string UserId);
        Task<List<EntAboutShowroom>> GetShowroomsByCity(string city);
        Task<bool> CheckBusinessExist(string UserId);
        Task<EntAboutShowroom?> GetShowroomByIdAsync(string id);

        Task<List<EntAboutShowroom>> GetRandomShowroomsAsync(int count = 3);
        Task<EntAboutShowroom?> GetByBusinessId(string BusinessId);
    }
}