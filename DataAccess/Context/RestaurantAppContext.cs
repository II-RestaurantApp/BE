using RestaurantAppBE.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace RestaurantAppBE.DataAccess.Context
{
    public class RestaurantAppContext: DbContext
    {
        public RestaurantAppContext(DbContextOptions<RestaurantAppContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ItemIngredient>().HasKey(i => new
            {
                i.IngredientId,
                i.ItemsItemId
            });

            builder.Entity<ItemIngredient>()
                .HasOne(am => am.Ingredient)
                .WithMany(a => a.Item)
                .HasForeignKey(am => am.IngredientId);

            builder.Entity<ItemIngredient>()
                .HasOne(am => am.Item)
                .WithMany(m => m.Ingrediente)
                .HasForeignKey(am => am.ItemsItemId);

        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
    }
}
