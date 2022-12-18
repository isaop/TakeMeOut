using BackEnd.Models;
using BackEnd.Services;
using BackEnd.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-user-by-id")]
        public async Task<ActionResult<UserDtoGetter>> GetUserByID(int id)
        {
            var users = await _userService.GetUserByID(id);
            UserDtoGetter requestedUser = new UserDtoGetter(users.Name, users.Surname, users.Email, users.PhoneNumber);
            return (users == null) ? NotFound("No user found") : requestedUser;
        }

        [HttpGet("get-all-users")]
        public async Task<ActionResult<List<UserDtoGetter>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            List<UserDtoGetter> requestedUsers = new List<UserDtoGetter>();
            
            for (int i = 0; i < users.Count; i++)
            {
                UserDtoGetter u = new UserDtoGetter(users[i].Name, users[i].Surname, users[i].Email, users[i].PhoneNumber);
                requestedUsers.Add(u);
            }
            return (requestedUsers == null) ? NotFound("No users found") : requestedUsers;
        }
    }
}
