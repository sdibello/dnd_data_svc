using System.Collections.Generic;
using System.Threading.Tasks;
using dnd_dal.dao;
using dnd_service_logic.BL;
using dnd_service_logic.dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dnd_graphql_svc.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FeatController : ControllerBase
    {
        private readonly IFeatLogic _featLogic;
        private readonly ILogger<FeatController> _logger;

        public FeatController(IFeatLogic featLogic, ILogger<FeatController> logger)
        {
            _featLogic = featLogic;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<DndFeat>>> GetFeat(string id)
        {
            var results = await _featLogic.GetFeatAsync(id);
            if (results.Count == 0)
            {
                _logger.LogInformation("Feat lookup returned no results for {FeatId}", id);
                return NotFound();
            }

            _logger.LogInformation("Feat lookup returned {Count} results for {FeatId}", results.Count, id);
            return results;
        }

        [HttpGet("{id}/requirement")]
        public async Task<ActionResult<FeatTree>> GetFeatTree(string id)
        {
            var data = await _featLogic.GetFeatRequirementsAsync(id);
            if (data == null)
            {
                _logger.LogInformation("Feat requirement lookup returned no results for {FeatId}", id);
                return NotFound();
            }

            return data;
        }
    }
}
