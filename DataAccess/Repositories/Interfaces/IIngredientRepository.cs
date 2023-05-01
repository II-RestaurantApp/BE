using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;

namespace RestaurantAppBE.DataAccess.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        Task<List<Ingredient>> GetIngredient();
        Task<Ingredient> GetIngredientById(int id);
        Task<int> UpdateIngredient(Ingredient ingredient, int id);
        Task<int> RegisterIngredient(IngredientDto ingredient);
        Task<int> DeleteIngredient(int id);
    }
}
