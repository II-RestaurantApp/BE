﻿using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;

namespace RestaurantAppBE.RestServices.Services.Interfaces
{
    public interface IIngredientService
    {
        Task<List<Ingredient>> GetIngredient();
        Task<Ingredient> GetIngredientById(int id);
        Task<int> UpdateIngredient(IngredientDto ingredient, int id);
        Task<int> DeleteIngredient(int id);
        Task<int> RegisterIngredient(IngredientDto ingredient);
    }
}
