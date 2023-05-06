using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Enums;

namespace RestaurantAppBE.RestServices.Services
{
    public interface ISessionService
    {
        SessionDataDto GetSessionInfo(HttpContext httpContext, int? userId = default, UserType usertype=default, string? sessionBearer = default);
    }
}
