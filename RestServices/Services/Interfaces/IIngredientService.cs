using RestaurantAppBE.DataAccess.DTOs;

namespace RestaurantAppBE.RestServices.Services.Interfaces
{
    public interface IIngredientService
    {
        Task<int> DeleteIngredient(int id);
        Task<int> RegisterIngredient(IngredientDto ingredient);
    }
}
