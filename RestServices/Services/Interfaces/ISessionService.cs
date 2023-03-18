using RestaurantAppBE.DataAccess.DTOs;

namespace RestaurantAppBE.RestServices.Services
{
    public interface ISessionService
    {
        SessionDataDto GetSessionInfo(HttpContext httpContext, int? userId = default, string? sessionBearer = default);
    }
}
