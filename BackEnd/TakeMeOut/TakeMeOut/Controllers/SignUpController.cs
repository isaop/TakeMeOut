
using Microsoft.AspNetCore.Mvc;
using TakeMeOut.Database.Models;
using TakeMeOut.Services;

namespace TakeMeOut.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignUpController : ControllerBase
    {

        private ISignUpService _signUpService;

        public SignUpController(ISignUpService signUpService)
        {
            _signUpService = signUpService;
        }
        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] User user)
        {

            if (user is null)
            {
                return BadRequest("Invalid client request");
            }

            bool result = await _signUpService.CheckIfUserExists(user);

            if (result == true)
            {
                return BadRequest("User Already Exists");
            }
            else
            {
                return Ok(user);
            }
        }
    }
}


