using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
using RestaurantAppBE.RestServices.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAppBE.RestServices.Services;
using System.Threading.Tasks;
using RestaurantAppBE.DataAccess.Enums;
using System.Security.Claims;

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
        public async Task<int?> RegisterComanda([FromBody] ComandaDto comanda)
        {
            int currentUserId = _authService.GetCurrentUserId();
            if (_authService.GetUserRole() == "ADMIN" || comanda.UserId == currentUserId)
            {
                return await _comandaService.RegisterComanda(comanda);
            }
            else
            {
                return 0;
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<int?> UpdateComanda([FromBody] ComandaDto comanda, [FromQuery] int id)
        {
            int currentUserId = _authService.GetCurrentUserId();
            if (_authService.GetUserRole() == "ADMIN")
            {
                return await _comandaService.UpdateComanda(comanda, id);
            }
            else
            {
                
                return await _comandaService.UpdateComanda(comanda, id, currentUserId);
                
            }
        }

        [Authorize(Roles = "ADMIN")]
        [HttpPut]
        [Route("status")]
        public async Task<int> UpdateStatusComanda([FromQuery] int id, [FromQuery] StatusComanda status)
        {
            return await _comandaService.UpdateStatusComanda(id, status); 
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

