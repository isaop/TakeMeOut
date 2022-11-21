using TakeMeOutBE.Models;

namespace TakeMeOutBE.Services
{
    public interface ISignUpService
    {
        public Task<bool> CheckIfUserExists(User user);
        public Task<bool> AddUserToDataBase(User user);
    }
}
