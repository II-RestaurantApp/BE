using System;
using RestaurantAppBE.DataAccess.DTOs;

namespace RestaurantAppBE.DataAccess.Repositories.Interfaces
{
    public interface IComandaRepository
    {
        Task<int> RegisterComanda(ComandaDto comanda);
    }
}

