using System.Collections.Generic;
using System.Linq;
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
        public RecipeIngredient Get(int id)
        {
            var recipeIngredientData = _db.RecipeIngredients
                .Include(ri => ri.Unit)
                .Include(ri => ri.Ingredient)
                .SingleOrDefault(m => m.Id == id); // change to Async

            return Map(recipeIngredientData);
        }

        // POST api/recipeIngredients
        [HttpPost]
        public void Post([FromBody]RecipeIngredient value)
        {
        }

        // PUT api/recipeIngredients/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]RecipeIngredient value)
        {
        }

        // DELETE api/recipeIngredients/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
