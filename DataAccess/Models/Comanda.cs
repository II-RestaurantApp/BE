using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantAppBE.DataAccess.Models
{
    public class Comanda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ComId { get; set; }
        public int Total { get; set; }

        [Display(Name = "UserId")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public List<ComandaItem>? Items { get; set; }
    }
}
