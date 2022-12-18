using BackEnd.Models;

namespace BackEnd.Services
{
    public interface IBusinessAccountService
    {
        public Task<BusinessAccount> GetBusinessAccountByID(int id);
        public Task<List<BusinessAccount>> GetAllBusinessAccounts();
    }
}
