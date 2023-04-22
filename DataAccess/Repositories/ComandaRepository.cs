using RestaurantAppBE.DataAccess.Context;
using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Repositories.Interfaces;

namespace RestaurantAppBE.DataAccess.Repositories
{
    public class ComandaRepository : IComandaRepository
    {
        public IConfiguration _configuration;
        public readonly RestaurantAppContext _context;

        public ComandaRepository(IConfiguration configuration, RestaurantAppContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<int> RegisterComanda(ComandaDto comanda)
        {
            await _context.Comenzi.AddAsync(new Models.Comanda
            {
                Items = comanda.Item,
                Total = comanda.Total,
                UserId = comanda.UserId,
                User = comanda.User
            });
            return await _context.SaveChangesAsync();

        }
    }
}