using System;

namespace Restaurant.Operations.Data.Models
{
    public class RecipeExecution
    {
        public int Id { get; set; }
        public DateTime ExecutedOn { get; set; }
        public string ExecutedBy { get; set; }
        public Recipe ExecutedRecipe { get; set; }

    }
}