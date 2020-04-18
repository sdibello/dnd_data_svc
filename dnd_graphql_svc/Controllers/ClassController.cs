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
        public async Task<ActionResult<DndCharacterclass>> GetClass(string id)
        {
            int intId;
            DndCharacterclass data;

            if (int.TryParse(id, out intId) == true)
            {
                data = _context.DndCharacterclass.Where(x => x.Id == intId).FirstOrDefault();
            }
            else
            {
                data = _context.DndCharacterclass.Where(x => x.Slug == id).FirstOrDefault();
            }

            if (data != null)
            {
                Console.WriteLine(string.Format("log - get class - ({0}) name = {1}", id, data.Name));
                return data;
            };

            Console.WriteLine(string.Format("log - get class - ({0}) - 404, not found", id));
            return NotFound();
        }

        [HttpGet("{id}/spells")]
        public async Task<ActionResult<List<ClassSpell>>> GetSpellClassLevel(int id)
        {
         
            var query = _context.DndSpellclasslevel.Where(scl => scl.CharacterClassId == id)
                .Join(
                    _context.DndSpell,
                    cl => cl.SpellId,
                    s => s.Id,
                    (cl, s) => new ClassSpell
                    {
                        SpellId = s.Id,
                        SpellName = s.Name,
                        Level = cl.Level,
                        ClassId = cl.CharacterClassId
                    })
                .OrderBy(g => g.Level).ThenBy(g => g.SpellName)
                .ToList();

            if (query != null)
            {
                Console.WriteLine(string.Format("log -GetSpellClassLevel - id = {0}", id));
                return query;
            };

            Console.WriteLine(string.Format("log - GetSpellClassLevel - id = {0}", id));
            return NotFound();
        }


    }
}