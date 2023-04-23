using RestaurantAppBE.DataAccess.DTOs;

namespace RestaurantAppBE.DataAccess.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<int> RegisterItem(ItemDto item);
        Task<int> UpdateItem(ItemDto item, int id);
    }
}
