using Microsoft.EntityFrameworkCore;
using Restaurant.Operations.Data.Models;

namespace Restaurant.Operations.Data.Context
{
    public class OperationsContext : DbContext
    {
        public OperationsContext(DbContextOptions<OperationsContext> options)
            : base(options)
        {
        }

        public DbSet<Unit> Units { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
    }
}
