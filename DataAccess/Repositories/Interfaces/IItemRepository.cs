using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;

namespace RestaurantAppBE.DataAccess.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<int> RegisterItem(ItemDto item);
        Task<Item> GetItem(ItemDto item);
        Task<Item> GetItemById(int id);
        Task<Ingredient> GetIngredient(IngredientDto ingredient);
        Task<Ingredient> GetIngredientById(int id);
    }
}
