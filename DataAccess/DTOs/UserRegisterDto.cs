using RestaurantAppBE.DataAccess.Enums;

namespace RestaurantAppBE.DataAccess.DTOs
{
    public class UserRegisterDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType type { get; set; }
    }
}
