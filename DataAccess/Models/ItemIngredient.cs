namespace RestaurantAppBE.DataAccess.Models
{
    public class ItemIngredient
    {
        public int ItemsItemId { get; set; }
        public Item Item    { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

    }
}
