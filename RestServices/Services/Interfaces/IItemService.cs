using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;

namespace RestaurantAppBE.RestServices.Services.Interfaces
{
    public interface IItemService
    {
        Task<int> DeleteItem(int id);
        Task<int> RegisterItem(ItemDto item);
        Task<int> UpdateItem(ItemDto item, int id);
        Task<List<Item>> GetItem();
        Task<Item> GetItemById(int id);
    }
}
