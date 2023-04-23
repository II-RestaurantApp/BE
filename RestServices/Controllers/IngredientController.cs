using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
using RestaurantAppBE.RestServices.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantAppBE.RestServices.Controllers
{
    [Route("ingredient")]
    [ApiController]
    public class IngredientController
    {
        private readonly IIngredientService _ingredientService;

        public IngredientController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpPost]
        public async Task<int> RegisterIngredient([FromBody] IngredientDto ingredient)
        {
            return await _ingredientService.RegisterIngredient(ingredient);
        }

    }
}
