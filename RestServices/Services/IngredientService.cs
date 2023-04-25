using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
using RestaurantAppBE.DataAccess.Repositories.Interfaces;
using RestaurantAppBE.RestServices.Services.Interfaces;

namespace RestaurantAppBE.RestServices.Services
{
    public class IngredientService : IIngredientService
    {
        private IIngredientRepository _ingredienRepository;

        public IngredientService(IIngredientRepository ingredientRepository)
        {
            _ingredienRepository = ingredientRepository;
        }

        public async Task<List<Ingredient>> GetIngredient()
        {
            return await _ingredienRepository.GetIngredient();
        }

        public async Task<Ingredient> GetIngredientById(int id)
        {
            return await _ingredienRepository.GetIngredientById(id);
        }

        public async Task<int> RegisterIngredient(IngredientDto ingredient)
        {
            return await _ingredienRepository.RegisterIngredient(ingredient);
        }
    }
}
