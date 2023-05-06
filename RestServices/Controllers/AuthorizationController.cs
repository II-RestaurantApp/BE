using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.RestServices.Services;
using RestaurantAppBE.RestServices.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantAppBE.RestServices.Controllers
{
    [Route("authorization")]
    public class AuthorizationController: ControllerBase
    {
        public IUserService _userService;
        public IAuthService _authService;
        public ISessionService _sessionService;

        public AuthorizationController(IUserService userService, IAuthService authService, ISessionService sessionService)
        {
            _userService = userService;
            _authService = authService;
            _sessionService = sessionService;
        }

        [HttpPost]
        public async Task<IActionResult> AuthToken([FromBody] UserDto user)
        {
            var authToken = await _authService.AuthToken(user);
            switch (authToken)
            {
                case null:
                    return Ok(new AuthResultDto
                    {
                        Success = false,
                        Error = "Bad Credentials"
                    });
                default:
                    var userData = await _userService.GetUser(user);
                    var sessionInfo = _sessionService.GetSessionInfo(HttpContext, userData.UserId, userData.type, authToken);

                    return Ok(new AuthResultDto
                    {
                        Success = true,
                        SessionData = new SessionDataDto
                        {
                            SessionId = sessionInfo.SessionId,
                            UserId = sessionInfo.UserId,
                            BearerToken = sessionInfo.BearerToken,
                            UserType = sessionInfo.UserType
                        }
                    }); 
            }
        }
    }
}
