using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
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

        public async Task<int?> RegisterItem(ItemDto item)
        {
            
            var result = await _itemRepository.RegisterItem(item);
            return result == 1 ? result : null;
        }

        public async Task<Item> GetItem(ItemDto item)
        {
            return await _itemRepository.GetItem(item);
        }

        public async Task<Item> GetItemById(int id)
        {

            /*var item = await _itemRepository.GetItemById(id);

            if (item == null)
            {
                return null;
            }

                return new ItemDto
                {   
                    Denumire = item.Denumire,
                    Gramaj = item.Gramaj,
                    Pret = item.Pret,
                    Ingrediente = item.Ingrediente
                };
            }*/ //asta era in cazul in care returnam un dto
            return await _itemRepository.GetItemById(id);
        }
        public async Task<Ingredient> GetIngredient(IngredientDto ingredient)
        {
            return await _itemRepository.GetIngredient(ingredient);
        }

        public async Task<Ingredient> GetIngredientById(int id)
        {
            return await _itemRepository.GetIngredientById(id);
        }
    }
}
