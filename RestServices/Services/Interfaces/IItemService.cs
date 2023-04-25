using RestaurantAppBE.DataAccess.DTOs;

namespace RestaurantAppBE.RestServices.Services.Interfaces
{
    public interface IItemService
    {
        Task<int> DeleteItem(int id);
        Task<int> RegisterItem(ItemDto item);
    }
}
