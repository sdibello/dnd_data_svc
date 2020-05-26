using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using dnd_dal.dto;

namespace dnd_dal.query.spell
{ 
    public class SpellQuery
    {
        private readonly dndContext _context;

        public SpellQuery(dndContext context)
        {
            _context = context;
        }

        //TODO - create a byClassAndLevel by int, int, and string, int
        //TODO 

        /// <summary>
        ///   Pull a list of "SpellClassLewvels items from the database, which lists all spells by class level.
        /// </summary>
        /// <param name="context">Database Concept</param>
        /// <param name="CasterClass">string value of the character class</param>
        /// <param name="CasterLevel">string value of the character level</param>
        /// <returns>A list of SpellClassLevels </returns>
        public List<SpellClassLevel> ByClassAndLevel(string CasterClass, string CasterLevel)
        {
            var preQuery = _context.DndCharacterclass.Where(cc => cc.Slug == CasterClass.ToLower()).ToList();

            var cclass = preQuery.FirstOrDefault();

            var query = _context.DndSpellclasslevel.Where(scl => scl.CharacterClassId == cclass.Id && scl.Level == long.Parse(CasterLevel))
                .Join(
                    _context.DndSpell,
                    cl => cl.SpellId,
                    s => s.Id,
                    (cl, s) => new SpellClassLevel
                    {
                        SpellId = s.Id,
                        ClassId = cl.CharacterClassId,
                        Level = cl.Level,
                        SpellName = s.Name
                    }
                )
                .Join(
                    _context.DndCharacterclass,
                    cl => cl.ClassId,
                    cc => cc.Id,
                    (cl, cc) => new SpellClassLevel
                    {
                        SpellId = cl.SpellId,
                        ClassId = cc.Id,
                        Level = cl.Level,
                        ClassName = cc.Name,
                        SpellName = cl.SpellName
                    })
                .OrderBy(g => g.ClassId)
                .ToList();

            Console.WriteLine(string.Format("log - searchSpellByClassAndLevel - casterClass = {0}/{1}", CasterClass, CasterLevel));
            if (query != null)
            {
                return query;
            };

            return null;
        }

    }
}
