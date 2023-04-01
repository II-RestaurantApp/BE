using RestaurantAppBE.DataAccess.Constants;
using RestaurantAppBE.DataAccess.DTOs;

namespace RestaurantAppBE.RestServices.Services
{
    public class SessionService: ISessionService
    {
        public SessionDataDto GetSessionInfo(HttpContext httpContext, int? userId = default, string? sessionBearer = default)
        {
            var sessionInfo = new SessionDataDto { };
            if (string.IsNullOrEmpty(httpContext.Session.GetString(SessionVariables.SessionKeyId)) || sessionBearer != null)
            {
                httpContext.Session.SetString(SessionVariables.SessionKeyId, Guid.NewGuid().ToString());
                httpContext.Session.SetString(SessionVariables.SessionUserId, userId.ToString());
                httpContext.Session.SetString(SessionVariables.SessionBearerToken, sessionBearer);
            }

            sessionInfo.SessionId = httpContext.Session.GetString(SessionVariables.SessionKeyId);
            sessionInfo.UserId = httpContext.Session.GetString(SessionVariables.SessionUserId);
            sessionInfo.BearerToken = httpContext.Session.GetString(SessionVariables.SessionBearerToken);

            return sessionInfo;
        }
    }
}
