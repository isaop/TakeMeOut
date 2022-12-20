using BackEnd.Database;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class UserService : IUserService
    {
        private readonly TakeMeOutDbContext _context;

        public UserService(TakeMeOutDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByID(int id)
        {
            return await _context.Users.Where(u => u.IdUser == id).FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> EditUser(User user)
        {
            var result = await CheckIfUserExists(user.IdUser);
            result.Name = user.Name;
            result.Surname = user.Surname;
            result.PhoneNumber = user.PhoneNumber;
            result.Email = user.Email;


            _context.Users.Update(result);
            await(_context.SaveChangesAsync());
            return result;
        }

        public async Task<User> CheckIfUserExists(int? id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.IdUser == id);
            if (user == null)
                return null;
            else
                return user;
        }

        public async Task<bool> ChangeUserPassword(int idUser, string oldPassword, string newPassword)
        {

            var user = await CheckIfUserExists(idUser);

            var hashedOldPassword = Hasher.CreateMD5(oldPassword);
            var hashedNewPassword = Hasher.CreateMD5(newPassword);


            if (user.Password == hashedOldPassword)
            {
                user.Password = hashedNewPassword;
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> DeleteUser(User u)
        {
            _context.Users.Remove(u);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool CheckIfUserActionHasUser(int idUs)
        {
            bool exists = false;
            foreach (var usactionss in _context.UserActions)
                if (usactionss.IdUser == idUs)
                    exists = true;

            return exists;
        }
        public bool CheckIfReviewHasUser(int idUs)
        {
            bool exists = false;
            foreach (var revieww in _context.Reviews)
                if (revieww.IdUser == idUs)
                    exists = true;

            return exists;
        }
        public bool CheckIfPaymentHasUser(int idUs)
        {
            bool exists = false;
            foreach (var paymentt in _context.Payments)
                if (paymentt.IdUser == idUs)
                    exists = true;

            return exists;
        }
        public bool CheckIfOrderHasUser(int idUs)
        {
            bool exists = false;
            foreach (var orderr in _context.Orders)
                if (orderr.IdEvent == idUs)
                    exists = true;

            return exists;
        }
    }
}
