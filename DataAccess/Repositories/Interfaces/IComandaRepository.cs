﻿using System;
using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Enums;
using RestaurantAppBE.DataAccess.Models;

namespace RestaurantAppBE.DataAccess.Repositories.Interfaces
{
    public interface IComandaRepository
    {
        Task<List<Comanda>> GetAllComanda();
        Task<Comanda> GetComanda(int id);
        Task<int> RegisterComanda(ComandaDto comanda);
        Task<int> UpdateComanda(ComandaDto comanda, int id);
        Task<int> UpdateStatusComanda(int id, StatusComanda status);
        
        Task<int> DeleteComanda(int id);
    }
}

