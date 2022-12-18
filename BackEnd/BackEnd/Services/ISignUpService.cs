using BackEnd.Models;

namespace BackEnd.Services
{
    public interface ISignUpService
    {
        public Task<bool> CheckIfUserExists(User user);
        public Task<bool> AddUserToDataBase(User user);
        public Task<bool> CheckIfBAExists(BusinessAccount ba);
        public Task<bool> AddBAToDataBase(BusinessAccount ba);



    }
}
