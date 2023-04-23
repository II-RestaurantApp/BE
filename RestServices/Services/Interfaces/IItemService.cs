using RestaurantAppBE.DataAccess.DTOs;

namespace RestaurantAppBE.RestServices.Services.Interfaces
{
    public interface IItemService
    {
        Task<int> RegisterItem(ItemDto item);
        Task<int> UpdateItem(ItemDto item, int id);
    }
}
