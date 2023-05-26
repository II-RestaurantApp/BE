using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
using RestaurantAppBE.RestServices.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAppBE.RestServices.Services;
using System.Threading.Tasks;
using RestaurantAppBE.DataAccess.Enums;
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
        public ComandaController(IComandaService comandaService)
        {
            _comandaService = comandaService;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterComanda([FromBody] ComandaDto comanda)
        {
            await _comandaService.RegisterComanda(comanda);
            try
            {
                return new OkObjectResult("Comanda inregistrata cu succes!");
            }
            catch (BadHttpRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComanda([FromBody] ComandaDto comanda, [FromQuery] int id)
        {

            await _comandaService.UpdateComanda(comanda, id);
            try
            {   
                return new OkObjectResult("Comanda modificata cu succes!");
            }
            catch (BadHttpRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        }

        [HttpPut]
        [Route("status")]
        public async Task<IActionResult> UpdateStatusComanda([FromQuery] int id, [FromQuery] StatusComanda status)
        {
            await _comandaService.UpdateStatusComanda(id, status);
            try
            {
                return new OkObjectResult("Status updatat cu succes!");
            }
            catch (BadHttpRequestException ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<int?> DeleteComanda([FromQuery] int id)
        {
            return await _comandaService.DeleteComanda(id);
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

