using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
using RestaurantAppBE.DataAccess.Repositories.Interfaces;
using RestaurantAppBE.RestServices.Services.Interfaces;

namespace RestaurantAppBE.RestServices.Services
{
    public class ItemService : IItemService
    {
        public IItemRepository _itemRepository;

        public async Task<List<Item>> GetItem()
        {
            return await _itemRepository.GetItem();
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _itemRepository.GetItemById(id);
        }

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<int> RegisterItem(ItemDto item)
        {
            return await _itemRepository.RegisterItem(item);
        }

        public async Task<int> DeleteItem(int id)
        {
            return await _itemRepository.DeleteItem(id);
        }
    }
}
