using BackEnd.Models;

namespace BackEnd.Services
{
    public interface IUserService
    {
        public Task<User> GetUserByID(int id);
        public Task<List<User>> GetAllUsers();
        public Task<User> EditUser(User user);

    }
}
