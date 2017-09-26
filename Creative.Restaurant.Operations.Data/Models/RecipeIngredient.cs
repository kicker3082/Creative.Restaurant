namespace Restaurant.Operations.Data.Models
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public Ingredient Ingredient { get; set; }
        public decimal Quantity { get; set; }
        public Unit Unit { get; set; }
    }
}