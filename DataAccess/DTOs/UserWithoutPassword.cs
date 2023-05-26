using RestaurantAppBE.DataAccess.Enums;

namespace RestaurantAppBE.DataAccess.DTOs
{
    public class UserWithoutPassword
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserType type { get; set; }
    }
}
