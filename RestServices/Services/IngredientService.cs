using RestaurantAppBE.DataAccess.DTOs;
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

        public async Task<int> RegisterIngredient(IngredientDto ingredient)
        {
            return await _ingredienRepository.RegisterIngredient(ingredient);
        }

        public async Task<int> DeleteIngredient(int id)
        {
            return await _ingredienRepository.DeleteIngredient(id);
        }
    }
}
