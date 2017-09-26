namespace Creative.Restaurant.Operations.App.Api.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int[] RecipeIngredientIds { get; set; }
        public decimal MakesQuantity { get; set; }
        public string MakesUnitAbbr { get; set; }
    }
}