using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using dnd_dal.dao;
using dnd_service_logic.BL;
using dnd_service_logic.dto;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace dnd_graphql_svc.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SpellsController : ControllerBase
    {
        private readonly dndContext _context;
        private readonly ISpellLogic _spellLogic;
        private readonly ILogger<SpellsController> _logger;

        public SpellsController(dndContext context, ISpellLogic spellLogic, ILogger<SpellsController> logger)
        {
            _context = context;
            _spellLogic = spellLogic;
            _logger = logger;
        }

        [HttpGet("{id}/class")]
        public async Task<ActionResult<List<SpellCL>>> GetSpellClassLevel(string id)
        {
            var results = await _spellLogic.GetClassAsync(id);
            if (results.Count == 0)
            {
                _logger.LogInformation("Spell class lookup returned no results for {SpellId}", id);
                return NotFound();
            }

            _logger.LogInformation("Spell class lookup returned {Count} results for {SpellId}", results.Count, id);
            return results;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Spell>>> GetSpell(string id)
        {
            var results = await _spellLogic.GetSpellsAsync(id);
            if (results.Count == 0)
            {
                _logger.LogInformation("Spell lookup returned no results for {SpellId}", id);
                return NotFound();
            }

            _logger.LogInformation("Spell lookup returned {Count} results for {SpellId}", results.Count, id);
            return results;
        }

        [HttpGet("{id}/school")]
        public async Task<ActionResult<List<SpellSchoolSubSchool>>> School(string id)
        {
            var results = await _spellLogic.GetSchoolsAsync(id);
            if (results.Count == 0)
            {
                _logger.LogInformation("Spell school lookup returned no results for {SpellId}", id);
                return NotFound();
            }

            _logger.LogInformation("Spell school lookup returned {Count} results for {SpellId}", results.Count, id);
            return results;
        }

        [HttpPost("index")]
        public async Task<ActionResult> UpdateIndex()
        {
            var appLuceneVersion = Lucene.Net.Util.LuceneVersion.LUCENE_48;
            var indexLocation = Path.Combine(AppContext.BaseDirectory, "Search", "index", "spells");
            Directory.CreateDirectory(indexLocation);

            using var dir = FSDirectory.Open(indexLocation);
            using var analyzer = new StandardAnalyzer(appLuceneVersion);
            using var writer = new IndexWriter(dir, new IndexWriterConfig(appLuceneVersion, analyzer));

            writer.DeleteAll();

            var data = await _context.DndSpell.AsNoTracking().ToListAsync();
            foreach (var spell in data)
            {
                var doc = new Document
                {
                    new StringField("name", spell.Name, Field.Store.YES),
                    new StringField("search_name", spell.Name.ToLower(), Field.Store.YES),
                    new StringField("id", spell.Id.ToString(), Field.Store.YES),
                    new StringField("slug", spell.Slug.ToLower(), Field.Store.YES)
                };

                writer.AddDocument(doc);
            }

            writer.Commit();
            _logger.LogInformation("Rebuilt spell index with {Count} documents", data.Count);
            return Ok(new { indexed = data.Count });
        }

        [HttpGet("{casterClass}/{casterLevel}")]
        public async Task<ActionResult<List<SpellCL>>> SearchSpellByClassAndLevel(string casterClass, string casterLevel)
        {
            if (!long.TryParse(casterLevel, out _))
            {
                return BadRequest("casterLevel must be numeric.");
            }

            var results = await _spellLogic.GetSpellsByClassAndLevelAsync(casterClass, casterLevel);
            if (results.Count == 0)
            {
                _logger.LogInformation("Spell class/level lookup returned no results for {CasterClass}/{CasterLevel}", casterClass, casterLevel);
                return NotFound();
            }

            _logger.LogInformation("Spell class/level lookup returned {Count} results for {CasterClass}/{CasterLevel}", results.Count, casterClass, casterLevel);
            return results;
        }
    }
}
