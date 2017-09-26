using System.Collections.Generic;

namespace Creative.Restaurant.Operations.Data.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<RecipeIngredient> Ingredients { get; set; }
        public decimal MakesQuantity { get; set; }
        public Unit MakesUnit { get; set; }
    }
}