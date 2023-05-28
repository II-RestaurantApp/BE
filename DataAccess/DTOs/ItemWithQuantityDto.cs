using RestaurantAppBE.DataAccess.Models;

namespace RestaurantAppBE.DataAccess.DTOs
{
    public class ItemWithQuantityDto
    {
        public Item Product { get; set; }
        public int Quantity { get; set; }
    }
}
