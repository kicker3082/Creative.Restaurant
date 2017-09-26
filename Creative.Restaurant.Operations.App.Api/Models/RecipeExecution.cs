using System;

namespace Creative.Restaurant.Operations.App.Api.Models
{
    public class RecipeExecution
    {
        public int Id { get; set; }
        public DateTime ExecutedOn { get; set; }
        public string ExecutedBy { get; set; }
        public Recipe ExecutedRecipe { get; set; }

    }
}