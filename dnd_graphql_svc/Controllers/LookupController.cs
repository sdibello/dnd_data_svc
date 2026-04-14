using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dnd_dal.dao;
using dnd_service_logic.BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dnd_graphql_svc.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LookupController : ControllerBase
    {
        private readonly ILookupLogic _lookupLogic;
        private readonly ILogger<LookupController> _logger;

        public LookupController(ILookupLogic lookupLogic, ILogger<LookupController> logger)
        {
            _lookupLogic = lookupLogic;
            _logger = logger;
        }

        [HttpGet("Rulebook")]
        public async Task<ActionResult<List<DndRulebook>>> GetRulebooks([FromQuery] string? ids)
        {
            List<DndRulebook> results;
            if (!string.IsNullOrWhiteSpace(ids))
            {
                try
                {
                    var listIds = ids.Split(',').Select(x => long.Parse(x.Trim())).ToList();
                    results = await _lookupLogic.GetRuleBooksAsync(listIds);
                }
                catch (System.FormatException)
                {
                    return BadRequest("ids must be a comma-separated list of numeric values.");
                }
            }
            else
            {
                results = await _lookupLogic.GetRuleBooksAsync();
            }

            if (results.Count == 0)
            {
                _logger.LogInformation("Rulebook lookup returned no results for ids {Ids}", ids);
                return NotFound();
            }

            return results;
        }
    }
}
