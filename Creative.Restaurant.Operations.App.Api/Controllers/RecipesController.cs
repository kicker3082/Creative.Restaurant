using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Operations.App.Api.Models;
using Restaurant.Operations.Data.Context;

namespace Restaurant.Operations.App.Api.Controllers
{
    [Route("api/[controller]")]
    public class RecipesController : Controller
    {
        OperationsContext _db;

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

        // GET api/recipes
        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            var recipes = _db.Recipes
                .Include(r => r.MakesUnit)
                .Include(r => r.Ingredients)
                .Select(Map); // change to Async

            return recipes;
        }

        // GET api/recipes/5
        [HttpGet("{id}")]
        public Recipe Get(int id)
        {
            var recipeData = _db.Recipes
                .Include(ri => ri.MakesUnit)
                .Include(ri => ri.Ingredients)
                .SingleOrDefault(m => m.Id == id); // change to Async

            return Map(recipeData);
        }

        // POST api/recipes
        [HttpPost]
        public void Post([FromBody]RecipeIngredient value)
        {
        }

        // PUT api/recipes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]RecipeIngredient value)
        {
        }

        // DELETE api/recipes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}