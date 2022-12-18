using BackEnd.Dtos;
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

        [HttpPost("sign-up-user")]
        public async Task<IActionResult> SignUpUser([FromBody]UserDto user)
        {

            User u = new User();
            u.Name = user.Name;
            u.PhoneNumber = user.PhoneNumber;
            u.Surname = user.Surname;
            u.Email = user.Email;
            u.Password = user.Password;



            if (user is null)
            {
                return BadRequest("Invalid client request");
            }

            bool result = await _signUpService.CheckIfUserExists(u);

            if (result == true)
            {
                return BadRequest("User Already Exists");
            }
            else
            {
                return Ok(user);
            }
        }

        [HttpPost("sign-up-business-account")]
        public async Task<IActionResult> SignUpBA([FromBody] BusinessAccountDto businessAccount)
        {

            BusinessAccount b = new BusinessAccount();
            b.ContactNumber = businessAccount.ContactNumber;
            b.Name = businessAccount.Name;
            b.Description = businessAccount.Description;
            b.Email = businessAccount.Email;
            b.Password = businessAccount.Password;
            b.IdVenue = businessAccount.IdVenue;

            if (b is null)
            {
                return BadRequest("Business Account is null");
            }

            bool result = await _signUpService.CheckIfBAExists(b);

            if (result == true)
            {
                return BadRequest("Business Account Already Exists");
            }
            else
            {
                return Ok(b);
            }
        }


    }
}
