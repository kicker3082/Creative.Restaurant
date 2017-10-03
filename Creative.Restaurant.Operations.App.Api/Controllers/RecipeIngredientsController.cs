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
    public class RecipeIngredientsController : Controller
    {
        readonly OperationsContext _db;

        public RecipeIngredientsController(OperationsContext context)
        {
            _db = context;
        }

        async Task<Data.Models.RecipeIngredient> Map(RecipeIngredient viewModel)
        {
            var unit = await _db.Units.SingleOrDefaultAsync(u => u.Abbr == viewModel.UnitAbbr);
            var ingredient = await _db.Ingredients.SingleOrDefaultAsync(ing => ing.Name == viewModel.IngredientName);

            var recipeIngredient = new Data.Models.RecipeIngredient
            {
                Id = viewModel.Id,
                Ingredient = ingredient,
                Unit = unit,
                Quantity = viewModel.Quantity
            };

            return recipeIngredient;
        }
        RecipeIngredient Map(Data.Models.RecipeIngredient dataModel)
        {
            return new RecipeIngredient
            {
                Id = dataModel.Id,
                IngredientName = dataModel.Ingredient?.Name,
                UnitAbbr = dataModel.Unit?.Abbr,
                Quantity = dataModel.Quantity
            };
        }

        // GET api/recipeIngredients
        [HttpGet]
        public IEnumerable<RecipeIngredient> Get()
        {
            var recipeIngredients = _db.RecipeIngredients
                .Include(ri => ri.Unit)
                .Include(ri => ri.Ingredient)
                .Select(Map); // change to Async

            return recipeIngredients;
        }

        // GET api/recipeIngredients/5
        [HttpGet("{id}")]
        public async Task<RecipeIngredient> Get(int id)
        {
            var recipeIngredientData = await _db.RecipeIngredients
                .Include(ri => ri.Unit)
                .Include(ri => ri.Ingredient)
                .SingleOrDefaultAsync(m => m.Id == id); // change to Async

            return Map(recipeIngredientData);
        }

        // POST api/recipeIngredients
        [HttpPost]
        public async Task<RecipeIngredient> Post([FromBody]RecipeIngredient value)
        {
            var recipeIngredient = await Map(value);

            await _db.RecipeIngredients.AddAsync(recipeIngredient);
            await _db.SaveChangesAsync();

            var dbRecipeIngredient = await _db.RecipeIngredients
                .Include(r => r.Ingredient)
                .Include(r => r.Unit)
                .SingleOrDefaultAsync(ri => ri.Ingredient.Name == value.IngredientName);

            return Map(dbRecipeIngredient);
        }

        // PUT api/recipeIngredients/5
        [HttpPut("{id}")]
        public async Task<RecipeIngredient> Put(int id, [FromBody]RecipeIngredient value)
        {
            var recipe = await Map(value);
            if (_db.RecipeIngredients.Any(r => r.Id == value.Id))
                _db.Update(value);
            else await _db.AddAsync(recipe);

            await _db.SaveChangesAsync();

            var dbRecipeIngredient = await _db.RecipeIngredients
                .Include(r => r.Ingredient)
                .Include(r => r.Unit)
                .SingleOrDefaultAsync(ri => ri.Ingredient.Name == value.IngredientName);

            return Map(dbRecipeIngredient);
        }

        // DELETE api/recipeIngredients/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
