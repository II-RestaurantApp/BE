using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RestaurantAppBE.DataAccess.Enums;

namespace RestaurantAppBE.DataAccess.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType type { get; set; }

        // public ICollection<Comanda> Comenzi { get; set; }
    }
}
