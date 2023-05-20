using MessagePack;
using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Enums;
using RestaurantAppBE.DataAccess.Models;

namespace RestaurantAppBE.RestServices.Services.Interfaces
{
    public interface IComandaService
    {
        Task<int?> RegisterComanda(ComandaDto comanda);
        Task<int> UpdateComanda(ComandaDto comanda, int id);
        Task<int> UpdateStatusComanda( int id, StatusComanda status);
        Task<int?> DeleteComanda(int id);
        Task<List<Comanda>> GetAllComanda();
        Task<List<Comanda>> GetAllComanda(int id);
        Task<Comanda> GetComanda(int id);
        Task<Comanda> GetComanda(int id, int userId);
    }
}
