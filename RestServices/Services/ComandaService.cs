using RestaurantAppBE.DataAccess.DTOs;
using RestaurantAppBE.DataAccess.Repositories.Interfaces;
using RestaurantAppBE.RestServices.Services.Interfaces;

namespace RestaurantAppBE.RestServices.Services
{
    public class ComandaService : IComandaService
    {
        public IComandaRepository _comandaRepository;


        public ComandaService(IComandaRepository comandaRepository)
        {
            _comandaRepository = comandaRepository;
        }

        public async Task<int?> RegisterComanda(ComandaDto comanda)
        {

            var result = await _comandaRepository.RegisterComanda(comanda);
            return result == 1 ? result : null;
        }
    }
}