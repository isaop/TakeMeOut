using BackEnd.Database;
using BackEnd.Dtos;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BackEnd.Services
{
    public class LoginUserService : ILoginUserService
    {
        private readonly TakeMeOutDbContext _context;
        private readonly ITokenService _tokenService;

        public LoginUserService(TakeMeOutDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<User> FindUserByEmail(string email)
        {
            var userByEmail = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            UserDtoLogin foundUser = new UserDtoLogin();
            foundUser.Email = userByEmail.Email;
            foundUser.Password = userByEmail.Password;
            return userByEmail;
        }

        public bool isPasswordValid(UserDtoLogin user, User userByEmail)
        {
            var hashedUserPassword = Hasher.CreateMD5(user.Password);
            if (userByEmail.Password == hashedUserPassword)
                return true;
            return false;
        }

        public async Task<UserRefreshToken> FindRefreshTokenByIDUser(User user)
        {
            var userRefreshToken = await _context.UserRefreshTokens.FirstOrDefaultAsync(u => u.IDUser == user.IdUser);
            return userRefreshToken;
        }

        public async Task AddTokenTable(User user, string refreshToken)
        {
            var refreshTokenModel = new UserRefreshToken
            {
                IDUser = (int)user.IdUser,
                RefreshToken = refreshToken,
                RefreshTokenExpiryTime = DateTime.Now.AddDays(7)
            };

            _context.UserRefreshTokens.Add(refreshTokenModel);
            await _context.SaveChangesAsync();
        }

        public async Task EditTokenTable(string refreshToken, UserRefreshToken userRefreshToken)
        {
            userRefreshToken.RefreshToken = refreshToken;
            await _context.SaveChangesAsync();
        }

        public async Task RefreshTokenTime(string refreshToken, UserRefreshToken userRefreshToken)
        {
            userRefreshToken.RefreshToken = refreshToken;
            userRefreshToken.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            await _context.SaveChangesAsync();
        }

        public async Task<Object> CreateTokenString(UserDtoLogin user)
        {
            var userByEmail = await FindUserByEmail(user.Email);
            if (userByEmail is null)
                return "Mail address not found";
            if (isPasswordValid(user, userByEmail) == false)
                return "Incorrect password";

            var userRefreshToken = await FindRefreshTokenByIDUser(userByEmail);
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Email), };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            if (userRefreshToken is null)
                await AddTokenTable(userByEmail, refreshToken);
            else if (userRefreshToken.RefreshTokenExpiryTime <= DateTime.Now)
                await RefreshTokenTime(refreshToken, userRefreshToken);
            else
                await EditTokenTable(refreshToken, userRefreshToken);

            return new AuthenticatedResponse
            {
                Token = accessToken,
                RefreshToken = refreshToken,
                IDUser = (int)userByEmail.IdUser
            };
        }
    }
}
