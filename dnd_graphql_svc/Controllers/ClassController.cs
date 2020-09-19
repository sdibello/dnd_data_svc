using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dnd_dal;
using Microsoft.EntityFrameworkCore;
using System.Text;
using dnd_service_logic.dto;

namespace dnd_graphql_svc.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ClassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly dndContext _context;

        public ClassController(dndContext context)
        {
            _context = context;
        }

        // Scaffold-DbContext "DataSource=D:\git\dnd_dal\dnd_dal\DataAccess\dnd.sqlite" Microsoft.EntityFra meworkCore.Sqlite
        // GET: api/Spells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<DndCharacterclass>>> GetClass(string id)
        {
            List<DndCharacterclass> results;
            var characterclasslogic = new dnd_service_logic.BL.ClassLogic();

            results = characterclasslogic.getDBClass(id);

            if (results != null)
            {
                Console.WriteLine(string.Format("log - GetClass - id = {0}", id));
                return results;
            };

            Console.WriteLine(string.Format("log - GetClass - id = {0}", id));
            return NotFound();


        }

        [HttpGet("{id}/spells")]
        public async Task<ActionResult<List<ClassSpell>>> GetSpellClassLevel(string id)
        {
            List<ClassSpell> results;
            var characterclasslogic = new dnd_service_logic.BL.ClassLogic();

            // get the character class ID
            results = characterclasslogic.getclassSpells(id);
            var ordered = results.OrderBy(c => c.Level).ThenBy(c => c.SpellName);

            if (ordered != null)
            {
                Console.WriteLine(string.Format("log -GetSpellClassLevel - id = {0}", id));
                return ordered.ToList();
            };

            Console.WriteLine(string.Format("log - GetSpellClassLevel - id = {0}", id));
            return NotFound();
        }
    }
}