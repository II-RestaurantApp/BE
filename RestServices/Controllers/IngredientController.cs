using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RestaurantAppBE.RestServices.Services.Interfaces;
using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace RestaurantAppBE.RestServices.Controllers
{
    [Route("ingredient")]
    [ApiController]
    public class IngredientController
    {
        private readonly IItemService _itemService;
        
        [HttpGet("{id}")]
        //[Route]
        public async Task<Ingredient> GetIngredient(int id)
        {
            var ingredient = await _itemService.GetIngredientById(id);
            if (ingredient == null)
            {
                return null;
            }
            else
            {
                return ingredient;
            }

        }

        /*[Route("ingredient")]
        [HttpGet("{f_idid}")]
        [Route("GetIngredientById")]
        public async Task<Ingredient> GetIngredientById(int f_idid)
        {
            var ingredient = await _itemService.GetIngredientById(f_idid);
            if (ingredient == null)
            {
                return null;
            }
            else
            {
                return ingredient;
            }
        }*/

    }
}
