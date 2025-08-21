using Dal;
using Entities;

namespace CarRentalApp.Services
{
    public class UserService : IUserService
    {
        public async Task AddUser(EntAppUser user)
        {
            await DalUser.AddUser(user);
        }

        public async Task<EntAppUser> GetUserByEmail(string email)
        {
            return await DalUser.GetUserByEmail(email);
        }

        public async Task<long> GetUserCount()
        {
            return await DalUser.GetUserCount();
        }
    }
}
