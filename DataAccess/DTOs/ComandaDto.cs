using RestaurantAppBE.DataAccess.Enums;
using RestaurantAppBE.DataAccess.Models;

namespace RestaurantAppBE.DataAccess.DTOs
{
    public class ComandaDto
    {
        public int Total { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public List<ItemWithQuantityDto>? Item { get; set; }
        public StatusComanda? status { get; set; }
    }
}
