using Microsoft.EntityFrameworkCore;
using TakeMeOutBE.Database;
using TakeMeOutBE.Models;

namespace TakeMeOutBE.Services
{
    public class SignUpService : ISignUpService
    {
        private readonly TakeMeOutContext _context;
        public SignUpService(TakeMeOutContext context)
        {
            _context = context;
        }

        public Task<bool> AddUserToDataBase(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckIfUserExists(User user)
        {
            var userEmail = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (userEmail == null)
            {

                user.Password = Hasher.CreateMD5(user.Password);
                var addedUser = await AddToDataBase(user);
            }
            else
            {
                return true;
            }
            return false;
        }
    }
}
