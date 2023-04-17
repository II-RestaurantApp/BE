using RestaurantAppBE.DataAccess.DTOs;

namespace RestaurantAppBE.RestServices.Services.Interfaces
{
    public interface IItemService
    {
        Task<int?> RegisterItem(ItemDto item);
    }
}
