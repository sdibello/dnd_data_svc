using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dnd_dal;
using dnd_graphql_svc.dto;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dnd_graphql_svc.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class FeatController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        private readonly dndContext _context;

        public FeatController(dndContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DndFeat>> GetFeat(string id)
        {
            int intId;
            DndFeat featdb;

            if (int.TryParse(id, out intId) == true)
            {
                featdb = _context.DndFeat.Where(x => x.Id == intId).FirstOrDefault();
            }
            else
            {
                featdb = _context.DndFeat.Where(x => x.Slug == id).FirstOrDefault();
            }

            if (featdb != null)
            {
                Console.WriteLine(string.Format("log - get feat - ({0}) name = {1}", id, featdb.Name));
                return featdb;
            };

            Console.WriteLine(string.Format("log - get spell - ({0}) - 404, not found", id));
            return NotFound();
        }

    }
}
