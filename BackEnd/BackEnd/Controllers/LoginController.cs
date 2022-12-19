using BackEnd.Models;
using BackEnd.Dtos;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDtoLogin user)
        {
            if (user is null)
                return BadRequest("Invalid client request");
            var loginResponse = await _loginService.CreateTokenString(user);
            return (loginResponse.GetType() == typeof(string)) ? Unauthorized(loginResponse) : Ok(loginResponse);
        }
    }
}
