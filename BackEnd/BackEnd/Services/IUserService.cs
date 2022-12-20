using BackEnd.Models;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public interface IUserService
    {
        public Task<User> GetUserByID(int id);
        public Task<List<User>> GetAllUsers();
        public Task<User> EditUser(User user);
        public Task<User> CheckIfUserExists(int? id);
        public Task<bool> ChangeUserPassword(int idUser, string oldPassword, string newPassword);
        public Task<bool> DeleteUser(User u);

        public bool CheckIfOrderHasUser(int idEv);

        public bool CheckIfReviewHasUser(int idEv);

        public bool CheckIfUserActionHasUser(int idEv);
        public bool CheckIfPaymentHasUser(int idEv);
    }
}
