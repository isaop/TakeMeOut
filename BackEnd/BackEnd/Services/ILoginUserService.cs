using BackEnd.Models;
using BackEnd.Dtos;

namespace BackEnd.Services
{
    public interface ILoginUserService
    {
        public Task<Object> CreateTokenString(UserDtoLogin user);
        public bool isPasswordValid(UserDtoLogin user, User userByEmail);
        public Task EditTokenTable(string refreshToken, UserRefreshToken userRefreshToken);
        public Task AddTokenTable(User user, string refreshToken);
        public Task<User> FindUserByEmail(string email);
        public Task<UserRefreshToken> FindRefreshTokenByIDUser(User user);
        //public Task<bool> ResetPassword(ResetPassword reset);
        //public Task<bool> ForgotPassword(string email, string encryptedEmail);
    }
}
