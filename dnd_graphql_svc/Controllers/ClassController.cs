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
    public class ClassController : ControllerBase
    {
        private readonly IClassLogic _classLogic;
        private readonly ILogger<ClassController> _logger;

        public ClassController(IClassLogic classLogic, ILogger<ClassController> logger)
        {
            _classLogic = classLogic;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<DndCharacterclass>>> GetClass(string id)
        {
            var results = await _classLogic.GetDbClassAsync(id);
            if (results.Count == 0)
            {
                _logger.LogInformation("Class lookup returned no results for {ClassId}", id);
                return NotFound();
            }

            return results;
        }

        [HttpGet("{id}/spells")]
        public async Task<ActionResult<List<ClassSpell>>> GetSpellClassLevel(string id)
        {
            var results = await _classLogic.GetClassSpellsAsync(id);
            if (results.Count == 0)
            {
                _logger.LogInformation("Class spell lookup returned no results for {ClassId}", id);
                return NotFound();
            }

            return results;
        }
    }
}
