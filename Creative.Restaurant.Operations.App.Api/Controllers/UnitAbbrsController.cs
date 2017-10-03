using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Creative.Restaurant.Operations.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Creative.Restaurant.Operations.App.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/UnitAbbrs")]
    public class UnitAbbrsController : Controller
    {
        readonly OperationsContext _db;

        public UnitAbbrsController(OperationsContext context)
        {
            _db = context;
        }

        // GET: api/UnitAbbrs
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var names = (List<string>)await _db.Units.Select(r => r.Abbr)
                .ToListAsync();

            return names;
        }

        // GET: api/UnitAbbrs/ounce
        [HttpGet("{abbr}", Name = "Get")]
        public async Task<int?> Get(string abbr)
        {
            var recipe = await _db.Units.SingleOrDefaultAsync(u => u.Abbr == abbr);
            return recipe?.Id;
        }
    }
}