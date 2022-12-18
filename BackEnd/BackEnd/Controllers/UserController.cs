using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    public struct UserStruct
    {
        public UserStruct(string name, string surname, string email, string phNumber)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phNumber;
        }

        public string Name { get; }
        public string Surname { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
    }

    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-user-by-id")]
        public async Task<ActionResult<UserStruct>> GetUserByID(int id)
        {
            var users = await _userService.GetUserByID(id);
            UserStruct u = new UserStruct(users.Name, users.Surname, users.Email, users.PhoneNumber);
            return (users == null) ? NotFound("No user found") : u;
        }

        [HttpGet("get-all-users")]
        public async Task<ActionResult<List<UserStruct>>> GetAllUsers()
        {
            List<UserStruct> userList = new List<UserStruct>();

            var users = await _userService.GetAllUsers();
            for (int i = 0; i < users.Count; i++)
            {
                UserStruct u = new UserStruct(users[i].Name, users[i].Surname, users[i].Email, users[i].PhoneNumber);
                userList.Add(u);
            }
            return (userList == null) ? NotFound("No users found") : userList;
        }
    }
}
