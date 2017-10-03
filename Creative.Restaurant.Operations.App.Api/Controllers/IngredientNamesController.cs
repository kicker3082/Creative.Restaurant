using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Creative.Restaurant.Operations.Data.Context;
using Creative.Restaurant.Operations.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Creative.Restaurant.Operations.App.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/IngredientNames")]
    public class IngredientNamesController : Controller
    {
        readonly OperationsContext _db;

        public IngredientNamesController(OperationsContext context)
        {
            _db = context;
        }

        // GET: api/IngredientNames
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var names = (List<string>)await _db.Ingredients.Select(r => r.Name)
                .ToListAsync();

            return names;
        }

        // GET: api/IngredientNames/Sugar
        [HttpGet("{name}", Name = "Get")]
        public async Task<int?> Get(string name)
        {
            var recipe = await _db.Ingredients.SingleOrDefaultAsync(r => r.Name == name);
            return recipe?.Id;
        }
    }
}