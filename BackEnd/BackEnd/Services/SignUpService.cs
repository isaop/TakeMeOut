using BackEnd.Database;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services
{
    public class SignUpService : ISignUpService
    {
        private readonly TakeMeOutDbContext _context;
        public SignUpService(TakeMeOutDbContext context)
        {
            _context = context;
        }
        

        public async Task<bool> CheckIfUserExists(User user)
        {
            var userEmail = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (userEmail == null)
            {
                if (user.Password != null)
                {

                    user.Password = Hasher.CreateMD5(user.Password);
                    var addedUser = await AddUserToDataBase(user);
                }
            }
            else
            {
                return true;
            }
            return false;
        }
        
        public async Task<bool> AddUserToDataBase(User user)
        {
            _context.Users.Add(user);
            await(_context.SaveChangesAsync());
            return true;
        }

        public async Task<bool> CheckIfBAExists(BusinessAccount ba)
        {
            var baEmail = await _context.Users.FirstOrDefaultAsync(b => b.Email == ba.Email);
            if (baEmail == null)
            {
                if (ba.Password != null)
                {

                    ba.Password = Hasher.CreateMD5(ba.Password);
                    var addedBusinessAccount = await AddBAToDataBase(ba);
                }
            }
            else
            {
                return true;
            }
            return false;
        }

        public async Task<bool> AddBAToDataBase(BusinessAccount ba)
        {
            _context.BusinessAccounts.Add(ba);
            await (_context.SaveChangesAsync());
            return true;
        }
    }
}
