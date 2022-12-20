using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> RefreshAsync([FromBody] TokenAPI tokenAPI)
        {
            if (tokenAPI is null)
                return BadRequest("Invalid client request");
            var result = await _tokenService.RefreshToken(tokenAPI);
            return (result == null) ? BadRequest("Invalid client request") : Ok(result);
        }

        [HttpPost, Authorize]
        [Route("revoke")]
        public async Task<IActionResult> Revoke()
        {
            var email = User.Identity.Name;
            var result = await _tokenService.Revoke(email);
            if (!result)
                return BadRequest();
            return NoContent();
        }
    }
}
