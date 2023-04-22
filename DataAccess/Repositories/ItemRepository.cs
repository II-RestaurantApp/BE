using Microsoft.EntityFrameworkCore;
using RestaurantAppBE.DataAccess.Context;
using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
using RestaurantAppBE.DataAccess.Repositories.Interfaces;

namespace RestaurantAppBE.DataAccess.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public IConfiguration _configuration;
        public readonly RestaurantAppContext _context;

        public ItemRepository(IConfiguration configuration, RestaurantAppContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        public async Task<int> RegisterItem(ItemDto item)
        {
            await _context.Items.AddAsync(new Models.Item
            {
                Denumire = item.Denumire,
                Gramaj = item.Gramaj,
                Pret = item.Pret,
                Ingrediente = item.Ingrediente,

            });

            return await _context.SaveChangesAsync();
            
        }
        public async Task<Item> GetItem(ItemDto item)
        {
            var itemFound = await _context.Items.FirstOrDefaultAsync(currentItem => currentItem.Denumire == item.Denumire);
            if (itemFound != null)
            {
                return itemFound;
            }
            else
            {
                return null;
            }
        }

        public async Task<Item> GetItemById(int id)
        {
            //return await _context.Items.FindAsync(id);
            return await _context.Items.FirstOrDefaultAsync(currentItem => currentItem.Id == id);
        }

        public async Task<Ingredient> GetIngredient(IngredientDto ingredient)
        {
            var ingredientFound = await _context.Ingredients.FirstOrDefaultAsync(currentIngredient => currentIngredient.IngrName == ingredient.IngrName);
            if (ingredientFound != null)
            {
                return ingredientFound;
            }
            else
            {
                return null;
            }
        }

        public async Task<Ingredient> GetIngredientById(int id)
        {
            return await _context.Ingredients.FirstOrDefaultAsync(currentIngredient => currentIngredient.IngrId == id);
        }


    }
}
