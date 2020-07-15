using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using dnd_dal.dto;
using Microsoft.EntityFrameworkCore.Sqlite.Scaffolding.Internal;
using System.Security.Cryptography;

namespace dnd_dal.query.spell
{
    public class SpellQuery
    {
        private readonly dndContext _context;

        public SpellQuery(dndContext context)
        {
            _context = context;
        }

        #region SpellsByClassAndLevel 

        /// <summary>
        ///   Pull a list of "SpellClassLewvels items from the database, which lists all spells by class level.
        /// </summary>
        /// <param name="context">Database Concept</param>
        /// <param name="CasterClass">string value of the character class</param>
        /// <param name="CasterLevel">string value of the character level</param>
        /// <returns>A list of SpellClassLevels </returns>
        public List<SpellClassLevel> ByClassAndLevel(string CasterClass, string CasterLevel)
        {
            Console.WriteLine(string.Format("log - SpellQuery - ByClassAndLevel PARAMS {0} {1}", CasterClass, CasterLevel));
            var preQuery = _context.DndCharacterclass.Where(cc => cc.Slug == CasterClass.ToLower()).ToList();

            var cclass = preQuery.FirstOrDefault();

            if (cclass == null)
            {
                Console.WriteLine(string.Format("log - SpellQuery - ByClassAndLevel - Character Class Not Found", CasterClass, CasterLevel));
                return null;
            }

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

            if (query != null)
            {
                Console.WriteLine(string.Format("log - SpellQuery - ByClassAndLevel - ByClassAndLevel results {0}", query.Count()));
                return query;
            };

            Console.WriteLine(string.Format("log - SpellQuery - ByClassAndLevel - Not Spells Found", CasterClass, CasterLevel));
            return null;
        }

        #endregion

        #region Spell School

        private List<SpellSchoolSubSchool> schoolsBySlug(string slug)
        {
            var query =
                    from spell in _context.DndSpell
                    join spellschool in _context.DndSpellschool.DefaultIfEmpty() on spell.SchoolId equals spellschool.Id into ss
                    from ssr in ss.DefaultIfEmpty()
                    join subspellschool in _context.DndSpellschool.DefaultIfEmpty() on spell.SubSchoolId equals subspellschool.Id into subss
                    from subssr in subss.DefaultIfEmpty()
                    where spell.Slug.ToLower() == slug.ToLower()
                    select new SpellSchoolSubSchool
                    {
                        SpellId = spell.Id,
                        SchoolId = ssr.Id,
                        SchoolName = ssr.Name,
                        SubSchoolId = subssr.Id,
                        SubSchoolName = subssr.Name
                    };

            return query.ToList();
        }

        private List<SpellSchoolSubSchool> schoolsById(long spellId)
        {
            var query =
                    from spell in _context.DndSpell
                    join spellschool in _context.DndSpellschool.DefaultIfEmpty() on spell.SchoolId equals spellschool.Id into ss
                    from ssr in ss.DefaultIfEmpty()
                    join subspellschool in _context.DndSpellschool.DefaultIfEmpty() on spell.SubSchoolId equals subspellschool.Id into subss
                    from subssr in subss.DefaultIfEmpty()
                    where spell.Id == spellId
                    select new SpellSchoolSubSchool
                    {
                        SpellId = spell.Id,
                        SchoolId = ssr.Id,
                        SchoolName = ssr.Name,
                        SubSchoolId = subssr.Id,
                        SubSchoolName = subssr.Name
                    };

            return query.ToList();
        }

        public List<SpellSchoolSubSchool> SchoolBySpell(string parameter)
        {
            Console.WriteLine(string.Format("log - SchoolBySpell - PARAMS {0}", parameter));

            try
            {
                List<SpellSchoolSubSchool> data;
                if (long.TryParse(parameter, out long longId))
                    data = schoolsById(longId);
                else
                    data = schoolsBySlug(parameter);

                if (data != null) {
                    Console.WriteLine(string.Format("log - SpellQuery - ByClassAndLevel - SchoolBySpell results {0}", data.Count()));
                    return data;
                };
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        #endregion
    }
}
