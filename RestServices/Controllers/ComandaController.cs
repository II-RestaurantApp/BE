using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
using RestaurantAppBE.RestServices.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAppBE.RestServices.Services;
using System.Threading.Tasks;

namespace RestaurantAppBE.RestServices.Controllers
{
    [Route("comanda")]
    [ApiController]
    public class ComandaController
    {
        private readonly IComandaService _comandaService;
        public ComandaController(IComandaService comandaService)
        {
            _comandaService = comandaService;
        }

        [HttpPost]
        public async Task<int?> RegisterComanda([FromBody] ComandaDto comanda)
        {
            return await _comandaService.RegisterComanda(comanda);

        }

        [HttpPut]
        public async Task<int?> UpdateComanda([FromBody] ComandaDto comanda, [FromQuery] int id)
        {
            return await _comandaService.UpdateComanda(comanda, id);
        
        }


        [HttpGet]
        public async Task<List<Comanda>> GetAllComanda()
        {
            return await _comandaService.GetAllComanda();
        }

        [HttpGet]
       [Route("{id:int}")]
        public async Task<Comanda> GetComanda( int id)
        {
            return await _comandaService.GetComanda(id);
        }

    }
}

