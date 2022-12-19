using BackEnd.Database;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Services
{
    public class BusinessAccountService : IBusinessAccountService
    {
        private readonly TakeMeOutDbContext _context;

        public BusinessAccountService(TakeMeOutDbContext context)
        {
            _context = context;
        }

        public async Task<BusinessAccount> GetBusinessAccountByID(int id)
        {
            return await _context.BusinessAccounts.Where(e => e.IdBusinessAccount == id).FirstOrDefaultAsync();
        }

        public async Task<List<BusinessAccount>> GetAllBusinessAccounts()
        {
            return await _context.BusinessAccounts.ToListAsync();
        }

        public async Task<BusinessAccount> EditBusinessAccount(BusinessAccount ba)
        {
            var result = await CheckIfBusinessAccountExists(ba.IdBusinessAccount);
            result.Name = ba.Name;
            result.Description = ba.Description;
            result.ContactNumber = ba.ContactNumber;
            result.Email = ba.Email;
            result.IdVenue = ba.IdVenue;


            _context.BusinessAccounts.Update(result);
            await(_context.SaveChangesAsync());
            return result;
        }

        public async Task<BusinessAccount> CheckIfBusinessAccountExists(int? id)
        {
            var ba = await _context.BusinessAccounts.FirstOrDefaultAsync(b => b.IdBusinessAccount == id);
            if (ba == null)
                return null;
            else
                return ba;
        }

        public async Task<bool> ChangeBAPassword(int idBA, string oldPassword, string newPassword)
        {
            var ba = await CheckIfBusinessAccountExists(idBA);

            var hashedOldPassword = Hasher.CreateMD5(oldPassword);
            var hashedNewPassword = Hasher.CreateMD5(newPassword);


            if (ba.Password == hashedOldPassword)
            {
                ba.Password = hashedNewPassword;
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteBusinessAccount(BusinessAccount ba)
        {
            _context.BusinessAccounts.Remove(ba);
            await _context.SaveChangesAsync();
            return true;
        }
        public bool CheckIfEventHasBA(int idBa)
        {
            bool exists = false;
            foreach (var eventt in _context.Events)
                if (eventt.IdBusinessAccount == idBa)
                    exists = true;

            return exists;
        }
    }
}
