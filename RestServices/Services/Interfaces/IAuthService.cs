using RestaurantAppBE.DataAccess.DTOs;

namespace RestaurantAppBE.RestServices.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> AuthToken(UserDto user);
    }
}
