using BackEnd.Models;
using BackEnd.Dtos;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginBAController : ControllerBase
    {
        private readonly ILoginBAService _loginService;

        public LoginBAController(ILoginBAService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] BusinessAccountDtoLogin ba)
        {
            if (ba is null)
                return BadRequest("Invalid client request");
            var loginResponse = await _loginService.CreateTokenString(ba);
            return (loginResponse.GetType() == typeof(string)) ? Unauthorized(loginResponse) : Ok(loginResponse);
        }
    }
}
