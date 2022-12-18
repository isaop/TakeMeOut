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
    }
}
