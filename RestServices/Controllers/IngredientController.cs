using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
using RestaurantAppBE.RestServices.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantAppBE.RestServices.Services;

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

        [HttpGet]
        [Route("{id:int}")]
        public async Task<Ingredient> GetIngredient(int id)
        {
            return await _ingredientService.GetIngredientById(id);


        }

        [HttpGet]
        public async Task<List<Ingredient>> GetIngredient()
        {
            return await _ingredientService.GetIngredient();
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<int> RegisterIngredient([FromBody] IngredientDto ingredient)
        {
            return await _ingredientService.RegisterIngredient(ingredient);
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public async Task<int?> UpdateIngredient([FromBody] IngredientDto ingredient, [FromQuery] int id)
        {
            return await _ingredientService.UpdateIngredient(ingredient, id);
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<int> DeleteItem(int id)
        {
            return await _ingredientService.DeleteIngredient(id);
        }

    }
}
