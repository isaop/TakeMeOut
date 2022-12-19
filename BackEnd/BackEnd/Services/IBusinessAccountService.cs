using BackEnd.Models;

namespace BackEnd.Services
{
    public interface IBusinessAccountService
    {
        public Task<BusinessAccount> GetBusinessAccountByID(int id);
        public Task<List<BusinessAccount>> GetAllBusinessAccounts();

        public Task<BusinessAccount> EditBusinessAccount(BusinessAccount ba);

        public Task<bool> ChangeBAPassword(int idBA, string oldPassword, string newPassword);

        public Task<BusinessAccount> CheckIfBusinessAccountExists(int? id);


        public Task<bool> DeleteBusinessAccount(BusinessAccount ba);



    }
}
