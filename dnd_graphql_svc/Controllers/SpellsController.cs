using dnd_dal;
using dnd_service_logic.dto;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_graphql_svc.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class SpellsController : Controller
    {
        private readonly dndContext _context;
        //public Search.Search _find;

        public IActionResult Index()
        {
            return View();
        }

        public SpellsController(dndContext context)
        {
            _context = context;
            //_find = new Search.Search();
        }

        [HttpGet("{id}/class")]
        public async Task<ActionResult<List<SpellCL>>> GetSpellClassLevel(string id)
        {
            List<SpellCL> results;
            var spelllogic = new dnd_service_logic.BL.SpellLogic();

            results = spelllogic.getClass(id);

            if (results != null)
            {
                Console.WriteLine(string.Format("log - GetSpellClassLevel - id = {0}", id));
                return results;
            };

            Console.WriteLine(string.Format("log - GetSpellClassLevel - id = {0}", id));
            return NotFound();
        }

        // Scaffold-DbContext "DataSource=D:\git\dnd_dal\dnd_dal\DataAccess\dnd.sqlite" Microsoft.EntityFra meworkCore.Sqlite
        // GET: api/Spells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Spell>>> GetSpell(string id)
        {
            List<Spell> results;
            var spelllogic = new dnd_service_logic.BL.SpellLogic();

            results = spelllogic.getSpells(id);

            if (results != null)
            {
                Console.WriteLine(string.Format("log - GetSpellClassLevel - id = {0}", id));
                return results;
            };

            Console.WriteLine(string.Format("log - GetSpellClassLevel - id = {0}", id));
            return NotFound();
        }

        [HttpGet("{id}/school")]
        public ActionResult<List<SpellSchoolSubSchool>> School(string id)
        {
            List<SpellSchoolSubSchool> results;
            var logic = new dnd_service_logic.BL.SpellLogic();

            results = logic.getSchools(id);
 
            if (results != null)
            {
                Console.WriteLine(string.Format("log - searchSpellByClassAndLevel - Schools - returned {0} results", results.Count()));
                return results;
            }

            Console.WriteLine(string.Format("log - searchSpellByClassAndLevel - Schools - 404 Not found"));
            return NotFound();
        }

        [HttpGet("{id}/index")]
        public async Task<ActionResult<DndSpell>> updateIndex()
        {
            var AppLuceneVersion = Lucene.Net.Util.LuceneVersion.LUCENE_48;

            var indexLocation = @"C:\Index";
            var dir = FSDirectory.Open(indexLocation);

            var analyzer = new StandardAnalyzer(AppLuceneVersion);

            var indexconfig = new Lucene.Net.Index.IndexWriterConfig(AppLuceneVersion, analyzer);
            var write = new IndexWriter(dir, indexconfig);

            var data = _context.DndSpell.ToList();

            foreach (var spell in data)
            {
                Document doc = new Document
                {
                    new StringField("name", spell.Name,Field.Store.YES),
                    new StringField("search_name", spell.Name.ToLower(),Field.Store.YES),
                    new StringField("id", spell.Id.ToString(),Field.Store.YES),
                    //new StringField("desc", spell.Description.ToLower(),Field.Store.YES),
                    new StringField("slug", spell.Slug.ToLower(),Field.Store.YES),
                };

                Console.WriteLine(string.Format(" writing {0}", spell.Name));
                write.AddDocument(doc);
                write.Flush(triggerMerge: false, applyAllDeletes: false);
                write.Commit();
            }

            return NotFound();
        }

        [HttpGet("{casterClass}/{casterlevel}")]
        public async Task<ActionResult<List<SpellCL>>> searchSpellByClassAndLevel(String casterClass, string casterlevel)
        {

            var logic = new dnd_service_logic.BL.SpellLogic();
            var results = logic.getSpellsByClassAndLevel(casterClass, casterlevel);

            if (results != null)
            {
                if (results.Count != 0)
                {
                    Console.WriteLine(string.Format("log - searchSpellByClassAndLevel - SpellController = {0}/{1} - returned {2} results", casterClass, casterlevel, results.Count()));
                    return results;
                }
                else
                {
                    Console.WriteLine(string.Format("log - searchSpellByClassAndLevel - SpellController - NO RESULTS", casterClass, casterlevel));
                    return NotFound();
                }
            };

            Console.WriteLine(string.Format("log - searchSpellByClassAndLevel - SpellController = {0}/{1} - NOT FOUND", casterClass, casterlevel));
            return NotFound();
        }


    }
}