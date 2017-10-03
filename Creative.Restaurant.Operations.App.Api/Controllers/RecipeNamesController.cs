using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Creative.Restaurant.Operations.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Creative.Restaurant.Operations.App.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/RecipeNames")]
    public class RecipeNamesController : Controller
    {
        readonly OperationsContext _db;

        public RecipeNamesController(OperationsContext context)
        {
            _db = context;
        }
        
        // GET: api/RecipeNames
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var names = (List<string>)await _db.Recipes.Select(r => r.Name)
                .ToListAsync();

            return names;
        }

        // GET: api/RecipeNames/5
        [HttpGet("{name}", Name = "Get")]
        public async Task<int?> Get(string name)
        {
            var recipe = await _db.Recipes.SingleOrDefaultAsync(r => r.Name == name);
            return recipe?.Id;
        }
    }
}
