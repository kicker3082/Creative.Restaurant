using System;
using System.Linq;
using System.Threading.Tasks;
using Creative.Restaurant.Operations.App.Api.Models.Status;
using Creative.Restaurant.Operations.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Creative.Restaurant.Operations.App.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Status")]
    public class StatusController : Controller
    {
        readonly OperationsContext _db;

        public StatusController(OperationsContext context)
        {
            _db = context;
        }

        // GET: api/Status
        [HttpGet]
        public async Task<Status> Get()
        {
            var recipesCount = await _db.Recipes.CountAsync();
            var recipesIngredientsCount = await _db.Recipes.Include(r => r.Ingredients)
                .SelectMany(r => r.Ingredients)
                .CountAsync();

            return new Status
            {
                SystemIs = @"Up",
                StatusAsOf = DateTime.Now,
                RecipesStatus = new RecipesStatus
                {
                    NumberOfIngredients = recipesIngredientsCount,
                    NumberOfRecipes = recipesCount
                }
            };
        }
    }
}
