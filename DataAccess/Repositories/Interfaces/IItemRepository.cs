using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;

namespace RestaurantAppBE.DataAccess.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<int> DeleteItem(int id);
        Task<int> RegisterItem(ItemDto item);
        Task<List<Item>> GetItem();
        Task<Item> GetItemById(int id);
    }
}
