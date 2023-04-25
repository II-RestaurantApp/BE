using RestaurantAppBE.DataAccess.DTOs;

namespace RestaurantAppBE.DataAccess.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<int> DeleteItem(int id);
        Task<int> RegisterItem(ItemDto item);
    }
}
