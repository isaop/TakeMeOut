using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignUpController: ControllerBase
    {
        private readonly ISignUpService _signUpService;
        public SignUpController(ISignUpService signUpService)
        {
            _signUpService = signUpService;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(string name, string surname, string password, string email, string phoneNumber)
        {
            User user = new User();
            user.Name = name;
            user.Surname = surname;
            user.PhoneNumber = phoneNumber;
            user.Email = email;
            user.Password = password;

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
