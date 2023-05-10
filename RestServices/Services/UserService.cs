using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
using RestaurantAppBE.RestServices.Repositories.Interfaces;
using RestaurantAppBE.RestServices.Services.Interfaces;

namespace RestaurantAppBE.RestServices.Services
{
    public class UserService: IUserService
    {
        public IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUser(UserDto user)
        {
            return await _userRepository.GetUser(user);
        }
        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<int?> RegisterUser(UserRegisterDto user)
        {
            var foundUser = await _userRepository
                .GetUser(new UserDto
                {
                    Email = user.Email,
                    Password = user.Password
                });
            if (foundUser is not null)
            {
                return null;
            }
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            var result = await _userRepository.RegisterUser(user);
            return result == 1 ? result : null;

        }

        public async Task<int?> UpdateUser(UserRegisterDto user, int id)
        {
            return await _userRepository.UpdateUser(user, id);
        }
    }
}
