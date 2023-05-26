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
            if (comanda.Total == 0 || comanda.UserId == 0 || comanda.status == null || comanda.Item.Count == 0 || comanda.Item == null)
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
            var lastComanda = _context.Comenzi.OrderByDescending(comanda => comanda.ComId).FirstOrDefault();
            comanda.Item?.ForEach(async (item) =>
            {
                await _context.AddAsync(new ComandaItem
                {
                    ComandaId = lastComanda.ComId,
                    ItemItemId = item.Id,
                });
                lastComanda.Total += item.Pret;
            });

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateComanda(ComandaDto comanda, int id)
        {
            var alreadyExistingComanda =
                await _context.Comenzi
                    .Where((currentComanda) => currentComanda.ComId == id)
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
                        alreadyExistingComanda.UserId = comanda.UserId;


                        alreadyExistingComanda.Items = new List<ComandaItem>();
                        foreach (var item in comanda.Item)
                        {
                            var itemEntity = await _context.Items.FindAsync(item.Id);
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
                    else
                    {
                        throw new BadHttpRequestException("Comanda nu mai poate fi modificata");
                    }

                }
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Comanda>> GetAllComanda() { 
            var ComandaList = _context.Comenzi.ToListAsync();

            return await ComandaList;
        }

        public async Task<Comanda> GetComanda(int id)
        
        {
            var alreadyExistingComanda =
                await _context.Comenzi
                    .Where((currentComanda) => currentComanda.ComId == id)
                    .FirstOrDefaultAsync();

            return  alreadyExistingComanda;
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

        public async Task<int> UpdateStatusComanda(int id, StatusComanda status)
        {
            var alreadyExist = await _context.Comenzi
                    .Where((currentComanda) => currentComanda.ComId == id)
                    .FirstOrDefaultAsync();

            if(alreadyExist is not null)
            {
                if (status == StatusComanda.ANULATA && alreadyExist.status != StatusComanda.IN_ASTEPTARE)
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