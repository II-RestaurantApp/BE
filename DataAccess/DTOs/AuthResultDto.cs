namespace RestaurantAppBE.DataAccess.DTOs
{
    public class AuthResultDto
    {
        public bool Success { get; set; }
        public string ?Error { get; set; }
        public SessionDataDto ?SessionData { get; set; }

    }
}
