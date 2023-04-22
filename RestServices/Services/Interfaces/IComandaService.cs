using RestaurantAppBE.DataAccess.DTOs;


namespace RestaurantAppBE.RestServices.Services.Interfaces
{
    public interface IComandaService
    {
        Task<int?> RegisterComanda(ComandaDto comanda);
    }
}
