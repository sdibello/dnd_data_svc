using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dnd_dal;
using dnd_graphql_svc.dto;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace dnd_graphql_svc.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class SpellsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly dndContext _context;

        public SpellsController(dndContext context)
        {
            _context = context;
        }

        [HttpGet("{id}/class")]
        public async Task<ActionResult<List<SpellClassLevel>>> GetSpellClassLevel(int id)
        {

            var query = _context.DndSpellclasslevel.Where(scl => scl.SpellId == id)
                .Join(
                    _context.DndCharacterclass,
                    cl => cl.CharacterClassId,
                    cc => cc.Id,
                    (cl, cc) => new SpellClassLevel {
                        SpellId = cl.SpellId,
                        ClassId = cc.Id,
                        Level = cl.Level,
                        ClassName = cc.Name
                    })
                .OrderBy( g => g.ClassId)
                .ToList();

            if (query != null)
            {
                Console.WriteLine(string.Format("log - get spell class - id = {0}", id));  
                return query;
            };

            Console.WriteLine(string.Format("log - get spell class - id = {0}", id));
            return NotFound();
        }

        // Scaffold-DbContext "DataSource=D:\git\dnd_dal\dnd_dal\DataAccess\dnd.sqlite" Microsoft.EntityFra meworkCore.Sqlite
        // GET: api/Spells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DndSpell>> GetSpell(string id)
        {
            int intId;
            DndSpell spelldb;

            if (int.TryParse(id, out intId) == true)
            {
                spelldb = _context.DndSpell.Where(x => x.Id == intId).FirstOrDefault();
            } else {
                spelldb = _context.DndSpell.Where(x => x.Slug == id).FirstOrDefault();
            }

            if (spelldb != null)
            {
                Console.WriteLine(string.Format("log - get spell - ({0}) name = {1}", id, spelldb.Name));
                return spelldb;
            };

            Console.WriteLine(string.Format("log - get spell - ({0}) - 404, not found", id));
            return NotFound();
        }

    }
}