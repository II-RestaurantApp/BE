using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAppBE.DataAccess.Models
{
    public class Ingredient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IngrId { get; set; }
        public string IngrName { get; set; }
        
        public List<ItemIngredient>? Item { get; set; }
    }
}
