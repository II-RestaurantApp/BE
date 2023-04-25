using RestaurantAppBE.DataAccess.Context;
using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
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
            await _context.Comenzi.AddAsync(new Comanda
            {
                Total = comanda.Total,
                UserId = comanda.UserId
            });

            await _context.SaveChangesAsync();
            var lastComanda = _context.Comenzi.OrderByDescending(comanda => comanda.ComId).FirstOrDefault();
            comanda.Item?.ForEach(async (item) =>
            {
                await _context.AddAsync(new ComandaItem
                {
                    ComandaId = lastComanda.ComId,
                    ItemItemId = item.Id
                });
            });

            return await _context.SaveChangesAsync();

        }
    }
}