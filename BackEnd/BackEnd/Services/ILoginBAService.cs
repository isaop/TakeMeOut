using BackEnd.Dtos;
using BackEnd.Models;

namespace BackEnd.Services
{
    public interface ILoginBAService
    {
        public Task<Object> CreateTokenString(BusinessAccountDtoLogin ba);
        public bool isPasswordValid(BusinessAccountDtoLogin ba, BusinessAccount baByEmail);
        public Task EditTokenTable(string refreshToken, UserRefreshToken userRefreshToken);
        public Task AddTokenTable(BusinessAccount ba, string refreshToken);
        public Task<BusinessAccount> FindBAByEmail(string email);
        public Task<UserRefreshToken> FindRefreshTokenByIDBA(BusinessAccount ba);
    }
}
