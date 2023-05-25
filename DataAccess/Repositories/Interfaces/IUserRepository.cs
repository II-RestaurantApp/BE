using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;

namespace RestaurantAppBE.RestServices.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUser(UserDto user);
        Task<User> GetUserById(int id);
        Task<int> RegisterUser(UserRegisterDto user);
        Task<List<User>> GetUsers();
    }
}
