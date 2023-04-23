using RestaurantAppBE.DataAccess.Models;

namespace RestaurantAppBE.DataAccess.DTOs
{
    public class ItemDto
    {
        public string Denumire { get; set; }
        public double Gramaj { get; set; }
        public int Pret { get; set; }
        public List<Ingredient>? Ingrediente { get; set; }
    }
}
