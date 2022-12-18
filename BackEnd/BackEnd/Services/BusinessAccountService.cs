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
    }
}
