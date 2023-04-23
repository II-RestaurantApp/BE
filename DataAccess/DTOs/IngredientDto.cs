using RestaurantAppBE.DataAccess.Models;

namespace RestaurantAppBE.DataAccess.DTOs
{
    public class IngredientDto
    {   
        public string IngrId { get; set; }
        public string IngrName { get; set;}
        public List<ItemIngredient>? Item { get; set; }

    }
}
 