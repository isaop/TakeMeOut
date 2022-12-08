using BackEnd.Models;

namespace BackEnd.Services
{
    public interface ISignUpService
    {
        public Task<bool> CheckIfUserExists(User user);
        public Task<bool> AddToDataBase(User user);

    }
}
