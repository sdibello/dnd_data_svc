using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dnd_dal;
using dnd_dal.query.feat;
using dnd_service_logic.BL;
using dnd_service_logic.dto;


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

        public FeatController()
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<DndFeat>>> GetFeat(string id)
        {
            FeatLogic fl = new FeatLogic();

            var query = fl.GetFeat(id);

            if (query != null)
            {
                Console.WriteLine(string.Format("log - get feat - ({0}) name = {1}", id, query.First().Name));
                return query;
            };

            Console.WriteLine(string.Format("log - get feat - ({0}) - 404, not found", id));
            return NotFound();
        }


        // http://localhost:5241/api/v1/feat/681/requirement
        [HttpGet("{id}/requirement")]
        public async Task<ActionResult<FeatTree>> GetFeatTree(string id)
        {
            var data = new FeatTree();
            FeatLogic fl = new FeatLogic();
            data = fl.GetFeatRequirements(id);

            //DndFeat featdb = _context.DndFeat.Where(x => x.Id == id).FirstOrDefault();

            //if (featdb == null)
            //{
            //    Console.WriteLine(string.Format("log - get spell class - id = {0}", id));
            //    return NotFound();
            //};

            //data.RootFeatid = featdb.Id;
            //data.RootFeatName = featdb.Name;
            //featdb = null;

            //var queryRequired = _context.DndFeatrequiresfeat.Where(frf => frf.SourceFeatId == id)
            //    .Join(
            //        _context.DndFeat,
            //        frf => frf.RequiredFeatId,
            //        f => f.Id,
            //        (frf, f) => new BasicFeat
            //        {
            //            id = f.Id,
            //            name = f.Name
            //        })
            //    //.OrderBy(g => g.ClassId)
            //    .ToList();

            //var queryRequireBy = _context.DndFeatrequiresfeat.Where(frf => frf.RequiredFeatId == id)
            //.Join(
            //    _context.DndFeat,
            //    frf => frf.SourceFeatId,
            //    f => f.Id,
            //    (frf, f) => new BasicFeat
            //    {
            //        id = f.Id,
            //        name = f.Name
            //    })
            ////.OrderBy(g => g.ClassId)
            //.ToList();

            //data.requiredFeats = queryRequired;
            //data.FeatsRequiredBy = queryRequireBy;

            //queryRequired = null;
            //queryRequireBy = null;


            //Console.WriteLine(string.Format("log - get spell class - id = {0}", id));
            return data;
        }

    }
}
