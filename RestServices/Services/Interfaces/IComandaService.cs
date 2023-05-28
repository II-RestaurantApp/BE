using MessagePack;
using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Enums;
using RestaurantAppBE.DataAccess.Models;

namespace RestaurantAppBE.RestServices.Services.Interfaces
{
    public interface IComandaService
    {
        Task<int?> RegisterComanda(ComandaDto comanda);
        Task<int> UpdateComanda(Comanda comanda, int id);
        Task<int> UpdateComanda(ComandaDto comanda, int id, int currentUserId);
        Task<int> UpdateStatusComanda( int id, StatusComanda status);
        Task<int?> DeleteComanda(int id);
        Task<int?> DeleteComanda(int id, int currentUserId);
        Task<List<Comanda>> GetAllComanda();
        Task<List<Comanda>> GetAllComanda(int id);
        Task<Comanda> GetComanda(int id);
        Task<Comanda> GetComanda(int id, int userId);
        
    }
}
