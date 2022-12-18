using BackEnd.Database;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

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
    }
}
