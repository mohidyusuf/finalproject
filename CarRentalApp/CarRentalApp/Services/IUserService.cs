using Entities;

namespace CarRentalApp.Services
{
    public interface IUserService
    {
        Task<EntAppUser> GetUserByEmail(string email);
        Task<long> GetUserCount();
        Task AddUser(EntAppUser user);
    }
}
