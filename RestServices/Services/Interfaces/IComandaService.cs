using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Models;

namespace RestaurantAppBE.RestServices.Services.Interfaces
{
    public interface IComandaService
    {
        Task<int?> RegisterComanda(ComandaDto comanda);
        Task<int> UpdateComanda(ComandaDto comanda, int id);
        Task<int?> DeleteComanda(int id);
        Task<List<Comanda>> GetAllComanda();
        Task<Comanda> GetComanda(int id);
    }
}
