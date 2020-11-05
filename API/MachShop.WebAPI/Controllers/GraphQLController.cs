using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using MachShop.WebAPI.GraphQL.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MachShop.WebAPI.Controllers
{
    [Route("[controller]")]
    public class GraphQlController : Controller
    {
        private readonly ILogger<GraphQlController> _logger;
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public GraphQlController(
            ILogger<GraphQlController> logger, ISchema schema, IDocumentExecuter documentExecuter)
        {
            _logger = logger;
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> PostQuery([FromBody] GraphQlQueryDto queryDto)
        {
            if (queryDto is null)
            {
                throw new ArgumentNullException(nameof(queryDto));
            }
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = queryDto.Query,
                Inputs = queryDto.Variables?.ToInputs()
            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }
    }
}