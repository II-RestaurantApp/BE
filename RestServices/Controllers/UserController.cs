using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
using RestaurantAppBE.RestServices.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantAppBE.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<User> GetUser(int id)
        {
            return await _userService.GetUserById(id);
        }

        [HttpGet]
        public async Task<List<UserWithoutPassword>> GetUsers()
        {
            return (await _userService.GetUsers()).Select(user => new UserWithoutPassword()
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                type = user.type
            }).ToList();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterDto user)
        {
            var result = await _userService.RegisterUser(user);
            switch (result)
            {
                case null:
                    return Ok(new UserResponseDto
                    {
                        Success = false,
                        Message = "This email is already registered!"
                    });
                default:
                    return Ok(new UserResponseDto
                    {
                        Success = true,
                        Message = "User was successfuly registered!"
                    });
            }
        }
    }
}
