using RestaurantAppBE.DataAccess.DTOs;

namespace RestaurantAppBE.RestServices.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> AuthToken(UserDto user);

        public int GetCurrentUserId();

        public string GetUserRole();
    }
}
