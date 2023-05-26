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

        public async Task<List<Item>> GetItem()
        {
            var ItemList = await _context.Items.Include(item => item.Ingrediente).ToListAsync();
            return ItemList;
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _context.Items.FirstOrDefaultAsync(currentItem => currentItem.Id == id);
        }

        public async Task<int> RegisterItem(ItemDto item)
        {
            var alreadyExistingItem =
                await _context.Items
                    .Where((currentItem) => currentItem.Denumire.Equals(item.Denumire))
                    .FirstOrDefaultAsync();
            if (alreadyExistingItem is not null)
            {
                return 0;
            }

            await _context.Items.AddAsync(new Item
            {
                Denumire = item.Denumire,
                Gramaj = item.Gramaj,
                Pret = item.Pret
            });
            await _context.SaveChangesAsync();
            var lastItem = _context.Items.OrderByDescending(item => item.Id).FirstOrDefault();
            item.Ingrediente?.ForEach(async (ingredient) =>
            {
                await _context.AddAsync(new ItemIngredient
                {
                    ItemsItemId = lastItem.Id,
                    IngredientId = ingredient.IngrId
                });
            });
            return await _context.SaveChangesAsync();
        }

        
        public async Task<int> UpdateItem(ItemDto item, int id)
        {
            var alreadyExistingItem =
                await _context.Items
                    .Where((currentItem) => currentItem.Id == id)
                    .Include(item => item.Ingrediente)
                    .FirstOrDefaultAsync();

            if (alreadyExistingItem is null)
            {
                return 0;
            }

            alreadyExistingItem.Denumire = item.Denumire;
            alreadyExistingItem.Pret = item.Pret;
            alreadyExistingItem.Gramaj = item.Gramaj;
            alreadyExistingItem.Ingrediente?.ForEach(ingredient =>
            {
                _context.ItemIngredients.Remove(ingredient); 
            });
            await _context.SaveChangesAsync();
            alreadyExistingItem.Ingrediente = new List<ItemIngredient>();

            item.Ingrediente?.ForEach(ingredient =>
            {
                alreadyExistingItem.Ingrediente.Add(new ItemIngredient()
                {
                    IngredientId = ingredient.IngrId,
                    ItemsItemId = alreadyExistingItem.Id,
                });
            });

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item != null)
            {
                _context.Items.Remove(item);
                return await _context.SaveChangesAsync();
            }

            return 0;
        }
    }
}
