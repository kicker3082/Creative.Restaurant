namespace Restaurant.Operations.App.Api.Models
{
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public decimal Quantity { get; set; }
        public string UnitAbbr { get; set; }
    }
}