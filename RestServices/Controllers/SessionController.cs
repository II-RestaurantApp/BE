using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.RestServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantAppBE.RestServices.Controllers
{
    [Route("session")]
    [Authorize]
    [ApiController]
    public class SessionController : ControllerBase
    {
        public ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost]
        public async Task<IActionResult> IsSessionActive([FromBody]SessionDataDto sessionData)
        {
            return Ok();
        }
    }
}
