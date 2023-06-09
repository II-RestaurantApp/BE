﻿using Microsoft.EntityFrameworkCore;
using RestaurantAppBE.DataAccess.Context;
using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;
using RestaurantAppBE.DataAccess.Repositories.Interfaces;

namespace RestaurantAppBE.DataAccess.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        public IConfiguration _configuration;
        public readonly RestaurantAppContext _context;
        public IngredientRepository(IConfiguration configuration, RestaurantAppContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<List<Ingredient>> GetIngredient()
        {
            var IngredientList = _context.Ingredients.ToListAsync();
            return await IngredientList;
        }

        public async Task<Ingredient> GetIngredientById(int id)
        {
            return await _context.Ingredients.FirstOrDefaultAsync(currentIngredient => currentIngredient.IngrId == id);
        }


        public async Task<int> RegisterIngredient(IngredientDto ingredient)
        {
            var alreadyExistingItem =
                await _context.Ingredients
                    .Where((currentIngredient) => currentIngredient.IngrName.Equals(ingredient.IngrName))
                    .FirstOrDefaultAsync();
            if (alreadyExistingItem is not null)
            {
                return 0;
            }

            await _context.Ingredients.AddAsync(new Models.Ingredient
            {
                IngrName = ingredient.IngrName
            });

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateIngredient(IngredientDto ingredient, int id)
        {
            var alreadyExist = await _context.Ingredients.Where((currentIngredient) => currentIngredient.IngrId == id)
                    .FirstOrDefaultAsync();
            if (alreadyExist is not null)
            {
                alreadyExist.IngrName = ingredient.IngrName;

            }

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteIngredient(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);

            if (ingredient != null)
            {
                _context.Ingredients.Remove(ingredient);
                return await _context.SaveChangesAsync();
            }

            return 0;
        }

    }
}
