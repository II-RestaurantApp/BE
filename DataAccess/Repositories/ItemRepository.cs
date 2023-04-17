using RestaurantAppBE.DataAccess.Context;
using RestaurantAppBE.DataAccess.DTOs;
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
    }
}
