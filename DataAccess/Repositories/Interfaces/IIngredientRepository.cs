using RestaurantAppBE.DataAccess.DTOs;

namespace RestaurantAppBE.DataAccess.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        Task<int> RegisterIngredient(IngredientDto ingredient);
        Task<int> DeleteIngredient(int id);
    }
}
