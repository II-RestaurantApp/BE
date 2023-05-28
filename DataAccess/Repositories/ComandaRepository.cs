using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAppBE.DataAccess.Context;
using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Enums;
using RestaurantAppBE.DataAccess.Models;
using RestaurantAppBE.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;


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
            if (comanda.Total == 0 || comanda.UserId == 0 || comanda.Item.Count == 0 || comanda.Item == null)
            { 
                throw new BadHttpRequestException("Completeaza toate campurile!");
		    }

            await _context.Comenzi.AddAsync(new Comanda
            {
                Total = comanda.Total,
                UserId = comanda.UserId,
                status = StatusComanda.IN_ASTEPTARE,
            });

            await _context.SaveChangesAsync();
            var lastComanda = await _context.Comenzi.OrderByDescending(comanda => comanda.ComId).FirstOrDefaultAsync();
            comanda.Item?.ForEach(async (item) =>
            {
                await _context.AddAsync(new ComandaItem
                {
                    ComandaId = lastComanda.ComId,
                    ItemItemId = item.Product.Id,
                    Quantity = item.Quantity,
                });
            });

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateComanda(Comanda comanda, int id)
        {
            var alreadyExistingComanda =
                await _context.Comenzi
                    .Where((currentComanda) => currentComanda.ComId == id)
                    .Include((currentComanda) => currentComanda.Items)
                    .FirstOrDefaultAsync();

            if (comanda.Total == 0 || comanda.UserId == 0 || comanda.status == null)
                throw new BadHttpRequestException("Completeaza toate campurile!");
            else
            {
                if (alreadyExistingComanda is not null)
                {
                    if (alreadyExistingComanda.status == (int)StatusComanda.IN_ASTEPTARE)
                    {
                        alreadyExistingComanda.Total = comanda.Total;

                        alreadyExistingComanda.Items?.ForEach(item =>
                        {
                            var currentEntry = _context.ComandaItems.Where(entry => entry.ComandaId == id).FirstOrDefault();

                            _context.ComandaItems.Remove(currentEntry);
                        });

                        _context.SaveChanges();

                        alreadyExistingComanda.Items = new List<ComandaItem>();

                        foreach (var item in comanda.Items)
                        {
                            alreadyExistingComanda.Items.Add(item);
                        }
                    }
                    else
                    {
                        throw new BadHttpRequestException("Comanda nu mai poate fi modificata");
                    }

                }
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateComanda(ComandaDto comanda, int id, int currentUserId)
        {
            var alreadyExistingComanda =
                await _context.Comenzi
                    .Where((currentComanda) => currentComanda.ComId == id && currentComanda.UserId == currentUserId)
                    .FirstOrDefaultAsync();

            if (alreadyExistingComanda is not null)
            {
                alreadyExistingComanda.Total = comanda.Total;
                alreadyExistingComanda.UserId = comanda.UserId;


                alreadyExistingComanda.Items = new List<ComandaItem>();
                foreach (var item in comanda.Item)
                {
                    var itemEntity = await _context.Items.FindAsync(item.Product.Id);
                    if (itemEntity is not null)
                    {
                        alreadyExistingComanda.Items.Add(new ComandaItem
                        {
                            ComandaId = alreadyExistingComanda.ComId,
                            ItemItemId = itemEntity.Id
                        });
                    }
                }
            }

            return await _context.SaveChangesAsync();
        }
        
        public async Task<List<Comanda>> GetAllComanda() {
            var ComandaList = await _context.Comenzi
                .Include(c => c.Items).ThenInclude(i => i.Item)
                .ToListAsync();

            return ComandaList;
        }

        public async Task<List<Comanda>> GetAllComanda(int id)
        {
            var ComandaList = await _context.Comenzi
                .Where(comanda => comanda.UserId == id)
                .Include(c => c.Items).ThenInclude(i => i.Item)
                .ToListAsync();

            return ComandaList;
        }

        public async Task<Comanda> GetComanda(int id)
        
        {
            var alreadyExistingComanda =
                await _context.Comenzi
                    .Where((currentComanda) => currentComanda.ComId == id)
                    .Include(c => c.Items).ThenInclude(i => i.Item)
                    .FirstOrDefaultAsync();

            return  alreadyExistingComanda;
        }

        public async Task<Comanda> GetComanda(int id, int userId)

        {
            var alreadyExistingComanda =
                await _context.Comenzi
                    .Where((currentComanda) => currentComanda.ComId == id  && currentComanda.UserId == userId)
                    .FirstOrDefaultAsync();

            return alreadyExistingComanda;
        }


        public async Task<int> DeleteComanda(int id)
        {
            var alreadyExistingComanda =
               await _context.Comenzi
                   .Where((currentComanda) => currentComanda.ComId == id)
                   .FirstOrDefaultAsync();

            if (alreadyExistingComanda is not null)
            {
                _context.Comenzi.Remove(alreadyExistingComanda);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int?> DeleteComanda(int id, int currentUserId)
        {
            var alreadyExistingComanda =
               await _context.Comenzi
                   .Where((currentComanda) => currentComanda.ComId == id && currentComanda.UserId == currentUserId)
                   .FirstOrDefaultAsync();

            if (alreadyExistingComanda is not null)
            {
                _context.Comenzi.Remove(alreadyExistingComanda);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> UpdateStatusComanda(int id, StatusComanda status)
        {
            var alreadyExist = await _context.Comenzi
                    .Where((currentComanda) => currentComanda.ComId == id)
                    .FirstOrDefaultAsync();

            if(alreadyExist is not null)
            {
                if (status == StatusComanda.ANULATA)
                {
                    throw new BadHttpRequestException("Comanda nu mai poate fi anulata!");
                }
                else
                {
                    alreadyExist.status = status;
                }
                
            }

            return await _context.SaveChangesAsync();
        }

    }
}