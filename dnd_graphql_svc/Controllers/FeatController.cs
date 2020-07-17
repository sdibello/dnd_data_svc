using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dnd_dal;
using dnd_graphql_svc.dto;
using System.Web;
using dnd_dal.query.feat;


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
        private FeatQuery _query;

        public FeatController(dndContext context)
        {
            _context = context;
            var query = new FeatQuery(_context);
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
                if (id.IndexOf(' ') > 0) {
                    featdb = _context.DndFeat.Where(x => x.Name.ToLower() == HttpUtility.UrlDecode(id.ToLower())).FirstOrDefault();
                } else {
                    featdb = _context.DndFeat.Where(x => x.Slug.ToLower() == id.ToLower()).FirstOrDefault();
                }
            }

            if (featdb != null)
            {
                Console.WriteLine(string.Format("log - get feat - ({0}) name = {1}", id, featdb.Name));
                return featdb;
            };

            Console.WriteLine(string.Format("log - get feat - ({0}) - 404, not found", id));
            return NotFound();
        }


        // http://localhost:5241/api/v1/feat/681/requirement
        [HttpGet("{id}/requirement")]
        public async Task<ActionResult<FeatTree>> GetFeatTree(long id)
        {
            var data = new FeatTree();

            DndFeat featdb = _context.DndFeat.Where(x => x.Id == id).FirstOrDefault();

            if (featdb == null)
            {
                Console.WriteLine(string.Format("log - get spell class - id = {0}", id));
                return NotFound();
            };

            data.RootFeatid = featdb.Id;
            data.RootFeatName = featdb.Name;
            featdb = null;

            var queryRequired = _context.DndFeatrequiresfeat.Where(frf => frf.SourceFeatId == id)
                .Join(
                    _context.DndFeat,
                    frf => frf.RequiredFeatId,
                    f => f.Id,
                    (frf, f) => new BasicFeat
                    {
                        id = f.Id,
                        name = f.Name
                    })
                //.OrderBy(g => g.ClassId)
                .ToList();

            var queryRequireBy = _context.DndFeatrequiresfeat.Where(frf => frf.RequiredFeatId == id)
            .Join(
                _context.DndFeat,
                frf => frf.SourceFeatId,
                f => f.Id,
                (frf, f) => new BasicFeat
                {
                    id = f.Id,
                    name = f.Name
                })
            //.OrderBy(g => g.ClassId)
            .ToList();

            data.requiredFeats = queryRequired;
            data.FeatsRequiredBy = queryRequireBy;

            queryRequired = null;
            queryRequireBy = null;


            Console.WriteLine(string.Format("log - get spell class - id = {0}", id));
            return data;
        }

    }
}
