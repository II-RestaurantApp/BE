using RestaurantAppBE.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAppBE.DataAccess.Context
{
    public class RestaurantAppContext: DbContext
    {
        public RestaurantAppContext(DbContextOptions<RestaurantAppContext> options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
    }
}
