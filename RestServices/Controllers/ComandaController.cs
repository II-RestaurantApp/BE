using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
using RestaurantAppBE.RestServices.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAppBE.RestServices.Services;
using System.Threading.Tasks;
using RestaurantAppBE.DataAccess.Enums;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using RestaurantAppBE.DataAccess.Constants;
using RestaurantAppBE.Migrations;

namespace RestaurantAppBE.RestServices.Controllers
{
    [Route("comanda")]
    [ApiController]
    public class ComandaController
    {
        private readonly IComandaService _comandaService;
        private readonly IAuthService _authService;

        public ComandaController(IComandaService comandaService, IAuthService authService)
        {
            _comandaService = comandaService;
            _authService = authService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RegisterComanda([FromBody] ComandaDto comanda)
        {
            try
            {
                int currentUserId = _authService.GetCurrentUserId();
                if (_authService.GetUserRole() == "ADMIN" || comanda.UserId == currentUserId)
                {
                    await _comandaService.RegisterComanda(comanda);
                    return new OkResult();
                }
                else
                {
                    return new UnauthorizedObjectResult("User-ul nu este admin!");
                }
            }
            catch (BadHttpRequestException ex)
            { 
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateComanda([FromBody] Comanda comanda, [FromQuery] int id)
        {
            try
            {
                await _comandaService.UpdateComanda(comanda, id);
                return new OkResult();
            }
            catch (BadHttpRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut]
        [Route("status")]
        public async Task<IActionResult> UpdateStatusComanda([FromQuery] int id, [FromQuery] StatusComanda status)
        {
            await _comandaService.UpdateStatusComanda(id, status);
            try
            {
                return new OkResult();
            }
            catch (BadHttpRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        public async Task<int?> DeleteComanda([FromQuery] int id)
        {
            int currentUserId = _authService.GetCurrentUserId();
            if (_authService.GetUserRole() == "ADMIN")
            {
                return await _comandaService.DeleteComanda(id);
            }
            else
            {
                return await _comandaService.DeleteComanda(id, currentUserId);
            }  
        }

        [Authorize]
        [HttpGet]
        public async Task<List<Comanda>> GetAllComanda()
        {
            int currentUserId = _authService.GetCurrentUserId();
            if (_authService.GetUserRole() == "ADMIN")
            {
                return await _comandaService.GetAllComanda();
            }
            else
            {
                return await _comandaService.GetAllComanda(currentUserId);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}")]
        public async Task<Comanda> GetComanda( int id)
        {
            int currentUserId = _authService.GetCurrentUserId();

            if (_authService.GetUserRole() == "ADMIN")
            {
                return await _comandaService.GetComanda(id);
            }
            else
            {
                return await _comandaService.GetComanda(id, currentUserId);
            }
        }

    }
}

