using BackEnd.Database;
using BackEnd.Dtos;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BackEnd.Services
{
    public class LoginBAService : ILoginBAService
    {
        private readonly TakeMeOutDbContext _context;
        private readonly ITokenService _tokenService;

        public LoginBAService(TakeMeOutDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<BusinessAccount> FindBAByEmail(string email)
        {
            var baByEmail = await _context.BusinessAccounts.FirstOrDefaultAsync(b => b.Email == email);
            return baByEmail;
        }

        public bool isPasswordValid(BusinessAccountDtoLogin ba, BusinessAccount baByEmail)
        {
            var hashedBAPassword = Hasher.CreateMD5(ba.Password);
            if (baByEmail.Password == hashedBAPassword)
                return true;
            return false;
        }

        public async Task<UserRefreshToken> FindRefreshTokenByIDBA(BusinessAccount ba)
        {
            var userRefreshToken = await _context.UserRefreshTokens.FirstOrDefaultAsync(u => u.IDBusinessAccount == ba.IdBusinessAccount);
            return userRefreshToken;
        }

        public async Task AddTokenTable(BusinessAccount ba, string refreshToken)
        {
            var refreshTokenModel = new UserRefreshToken
            {
                IDBusinessAccount = (int)ba.IdBusinessAccount,
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

        public async Task<Object> CreateTokenString(BusinessAccountDtoLogin ba)
        {
            var baByEmail = await FindBAByEmail(ba.Email);
            if (baByEmail is null)
                return "Mail address not found";
            if (isPasswordValid(ba, baByEmail) == false)
                return "Incorrect password";

            var userRefreshToken = await FindRefreshTokenByIDBA(baByEmail);
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, ba.Email), };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();
            if (userRefreshToken is null)
                await AddTokenTable(baByEmail, refreshToken);
            else if (userRefreshToken.RefreshTokenExpiryTime <= DateTime.Now)
                await RefreshTokenTime(refreshToken, userRefreshToken);
            else
                await EditTokenTable(refreshToken, userRefreshToken);

            return new AuthenticatedResponse
            {
                Token = accessToken,
                RefreshToken = refreshToken,
                IDBusinessAccount = (int)baByEmail.IdBusinessAccount
            };
        }
    }
}
