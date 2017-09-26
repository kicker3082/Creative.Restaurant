using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Creative.Restaurant.Operations.App.Api.Models;
using Creative.Restaurant.Operations.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Creative.Restaurant.Operations.App.Api.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : Controller
    {
        readonly OperationsContext _db;

        public RecipesController(OperationsContext context)
        {
            _db = context;
        }

        Recipe Map(Data.Models.Recipe dataModel)
        {
            return new Recipe
            {
                Id = dataModel.Id,
                Name = dataModel.Name,
                Description = dataModel.Description,
                MakesQuantity = dataModel.MakesQuantity,
                MakesUnitAbbr = dataModel.MakesUnit?.Abbr,
                RecipeIngredientIds = dataModel.Ingredients.Select(ing => ing.Id).ToArray()
            };
        }

        async Task<Data.Models.Recipe> Map(Recipe recipe)
        {
            var unit = await _db.Units.SingleOrDefaultAsync(u => u.Abbr == recipe.MakesUnitAbbr);

            var ingredients = new List<Data.Models.RecipeIngredient>(recipe.RecipeIngredientIds.Length);

            foreach (var id in recipe.RecipeIngredientIds)
            {
                var ingredient = await _db.RecipeIngredients.SingleOrDefaultAsync(ing => ing.Id == id);
                ingredients.Add(ingredient);
            }

            return new Data.Models.Recipe
            {
                Id = recipe.Id,
                Name = recipe.Name,
                Description = recipe.Description,
                MakesQuantity = recipe.MakesQuantity,
                MakesUnit = unit,
                Ingredients = ingredients
            };
        }

        // GET api/recipes
        [HttpGet]
        public async Task<IEnumerable<Recipe>> Get()
        {
            List<Data.Models.Recipe> recipes = await _db.Recipes
                .Include(r => r.MakesUnit)
                .Include(r => r.Ingredients)
                .ToListAsync();

            var mappedRecipes = recipes.Select(Map);

            return mappedRecipes;
        }

        // GET api/recipes/5
        [HttpGet("{id}")]
        public async Task<Recipe> Get(int id)
        {
            var recipeData = await _db.Recipes
                .Include(ri => ri.MakesUnit)
                .Include(ri => ri.Ingredients)
                .SingleOrDefaultAsync(m => m.Id == id); // change to Async

            return Map(recipeData);
        }

        // POST api/recipes
        [HttpPost]
        public async Task Post([FromBody]Recipe value)
        {
            var recipe = await Map(value);
            if (_db.Recipes.Any(r => r.Id == value.Id))
                _db.Update(value);
            else await _db.AddAsync(recipe);

            await _db.SaveChangesAsync();
        }

        // PUT api/recipes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Recipe value)
        {
        }

        // DELETE api/recipes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}