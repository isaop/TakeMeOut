using BackEnd.Models;
using System.Security.Claims;

namespace BackEnd.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string expiredToken);
        public Task<AuthenticatedResponse> RefreshToken(TokenAPI tokenAPI);
        public Task<bool> Revoke(string email);
    }
}
