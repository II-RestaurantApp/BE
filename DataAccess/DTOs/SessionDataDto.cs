namespace RestaurantAppBE.DataAccess.DTOs
{
    public class SessionDataDto
    {
        public string SessionId { get; set; }
        public string UserId { get; set; }
        public string UserType { get; set; }
        public string BearerToken { get; set; }
    }
}
