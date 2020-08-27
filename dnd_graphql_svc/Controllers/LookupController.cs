using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dnd_dal;
using dnd_service_logic;

namespace dnd_graphql_svc.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]

    public class LookupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly dndContext _context;

        //[HttpGet("Rulebook")]
        //public async Task<ActionResult<List<dnd_dal.DndRulebook>>> getRulebooks()
        //{
        //    List<DndRulebook> results;
        //    var lookupLogic = new dnd_service_logic.BL.LookupLogic(_context);

        //    results = lookupLogic.getRuleBooks();

        //    if (results != null)
        //    {
        //        //Console.WriteLine(string.Format("log - GetSpellClassLevel - id = {0}", id));
        //        return results;
        //    };

        //    //Console.WriteLine(string.Format("log - GetSpellClassLevel - id = {0}", id));
        //    return NotFound();
        //}

        [HttpGet("Rulebook")]
        public async Task<ActionResult<List<dnd_dal.DndRulebook>>> getRulebooks(string ids)
        {
            List<DndRulebook> results = new List<DndRulebook>();
            var lookupLogic = new dnd_service_logic.BL.LookupLogic(_context);

            if(ids!=null)
            {
                if (ids.Length > 0)
                {
                    List<long> listIds = ids.Split(",").Select(long.Parse).ToList();
                    results = lookupLogic.getRuleBooks(listIds);
                }
            }
            else {
                results = lookupLogic.getRuleBooks();
            }

            if (results != null)
            {
                //Console.WriteLine(string.Format("log - GetSpellClassLevel - id = {0}", id));
                return results;
            };

            //Console.WriteLine(string.Format("log - GetSpellClassLevel - id = {0}", id));
            return NotFound();
        }
    }
}
