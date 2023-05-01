using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAppBE.DataAccess.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Denumire { get; set; }
        public double Gramaj { get; set; }
        public int Pret { get; set; }
        public List<ItemIngredient>? Ingrediente { get; set; }
    }
}
