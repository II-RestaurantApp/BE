﻿using RestaurantAppBE.DataAccess.Context;
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
    }
}
