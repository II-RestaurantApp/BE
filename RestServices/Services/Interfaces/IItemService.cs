using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;

namespace RestaurantAppBE.RestServices.Services.Interfaces
{
    public interface IItemService
    {
        Task<int?> RegisterItem(ItemDto item);
        Task<List<Item>> GetItem();
        Task<Item> GetItemById(int id);
        Task<Ingredient> GetIngredientById(int id);
        Task<Ingredient> GetIngredient(IngredientDto item);

    }
}
