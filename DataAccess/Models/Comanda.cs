using RestaurantAppBE.Migrations;

namespace RestaurantAppBE.DataAccess.Models
{
    public class ComandaItem
    {
        public int ComandaId { get; set; }
        public Comanda? Comanda { get; set; }
        public int ItemItemId { get; set; }
        public Item? Item { get; set; }

    }
}
