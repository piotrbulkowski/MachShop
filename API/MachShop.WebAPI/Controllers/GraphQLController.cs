using System;
using System.Threading.Tasks;
using MachShop.WebAPI.BuildingBlocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MachShop.WebAPI.Controllers
{
    public class GraphQLController : Controller
    {
        private readonly ILogger<GraphQLController> _logger;

        public GraphQLController(ILogger<GraphQLController> logger)
        {
            _logger = logger;
        }

        [HttpPost("[controller]")]
        public async Task<IActionResult> PostQuery([FromBody] GraphQlQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));

            return BadRequest("Not ready yet");
        }
    }
}