using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Repositories.Interfaces;
using RestaurantAppBE.RestServices.Services.Interfaces;

namespace RestaurantAppBE.RestServices.Services
{
    public class ItemService : IItemService
    {
        public IItemRepository _itemRepository;


        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<int> RegisterItem(ItemDto item)
        {
            return await _itemRepository.RegisterItem(item);
        }

        public async Task<int> UpdateItem(ItemDto item,int id)
        {
            return await _itemRepository.UpdateItem(item,id);
        }
    }
}
