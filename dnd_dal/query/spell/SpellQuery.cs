using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using dnd_dal.dto;
using Microsoft.EntityFrameworkCore.Sqlite.Query;
using Microsoft.EntityFrameworkCore.Sqlite.Scaffolding.Internal;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Lucene.Net.Index;
using System.Web;


namespace dnd_dal.query.spell
{
    public class SpellQuery
    {
        private readonly dndContext _context;

        public SpellQuery(dndContext context)
        {
            _context = context;
        }

        #region spell

        public List<dnd_dal.DndSpell> Query_dndSpellByID(long spellId )
        {
            var query =
                    from spell in _context.DndSpell
                    where spell.Id == spellId
                    select spell;

            return query.ToList();

        }

        public List<dnd_dal.DndSpell> Query_dndSpellByName(string name)
        {
            var query =
                    from spell in _context.DndSpell
                    where spell.Name.ToLower() == name.ToLower()
                    select spell;

            return query.ToList();

        }

        public List<dnd_dal.DndSpell> Query_dndSpellBySlug(string slug)
        {
            var query =
                    from spell in _context.DndSpell
                    where spell.Slug.ToLower() == slug.ToLower()
                    select spell;

            return query.ToList();

        }

        #endregion

        #region Character Class

        /// <summary>
        /// Takes in a list of long ids - which is equal to the ids of the chracter classes you need to view.
        /// </summary>
        /// <param name="ids">long - list of character classes</param>
        /// <returns></returns>
        public List<dnd_dal.DndCharacterclass> Query_dndCharacterClassByIds(List<long> ids)
        {
            var query =
                    from characterClass in _context.DndCharacterclass
                    where ids.Contains(characterClass.Id)
                    select characterClass;

            return query.ToList();
        }


        #endregion

        #region spellClass

        /// <summary>
        /// Returns a spell class level entry, for a spell ID.
        /// only accepts a single 
        /// </summary>
        /// <param name="id">long - id of the spell you are looking for.</param>
        /// <returns></returns>
        public List<dnd_dal.DndSpellclasslevel> Query_dndSpellClassLevelBySpellId(long id)
        {
            var query =
                from spellClassLevel in _context.DndSpellclasslevel
                where spellClassLevel.SpellId == id
                select spellClassLevel;

            return query.ToList();
        }


        public List<SpellClassLevel> Query_SpellClassByName(string name)
        {
            var query =
                    from cc in _context.DndCharacterclass
                    join scl in _context.DndSpellclasslevel.DefaultIfEmpty() on cc.Id equals scl.CharacterClassId into spell_class_level
                    from spellcl in spell_class_level.DefaultIfEmpty()
                    join s in _context.DndSpell.DefaultIfEmpty() on spellcl.SpellId equals s.Id into sp
                    from spell in sp.DefaultIfEmpty()
                    where spell.Name.ToLower() == name.ToLower()
                    select new SpellClassLevel
                    {
                        SpellId = spell.Id,
                        SpellName = spell.Name,
                        ClassId = spellcl.CharacterClassId,
                        ClassName = cc.Name,
                        LevelForClass = spellcl.Level
                    };


            return query.ToList();
        }

        public List<SpellClassLevel> Query_SpellClassById(long id)
        {
            var query =
                    from cc in _context.DndCharacterclass
                    join scl in _context.DndSpellclasslevel.DefaultIfEmpty() on cc.Id equals scl.CharacterClassId into spell_class_level
                    from spellcl in spell_class_level.DefaultIfEmpty()
                    join s in _context.DndSpell.DefaultIfEmpty() on spellcl.SpellId equals s.Id into sp
                    from spell in sp.DefaultIfEmpty()
                    where spell.Id == id
                    select new SpellClassLevel
                    {
                        SpellId = spell.Id,
                        SpellName = spell.Name,
                        ClassId = spellcl.CharacterClassId,
                        ClassName = cc.Name,
                        LevelForClass = spellcl.Level
                    };


            return query.ToList();
        }

        public List<SpellClassLevel> Query_SpellClassBySlug(string slug)
        {
            var query =
                    from cc in _context.DndCharacterclass
                    join scl in _context.DndSpellclasslevel.DefaultIfEmpty() on cc.Id equals scl.CharacterClassId into spell_class_level
                    from spellcl in spell_class_level.DefaultIfEmpty()
                    join s in _context.DndSpell.DefaultIfEmpty() on spellcl.SpellId equals s.Id into sp
                    from spell in sp.DefaultIfEmpty()
                    where spell.Slug.ToLower() == slug.ToLower()
                    select new SpellClassLevel
                    {
                        SpellId = spell.Id,
                        SpellName = spell.Name,
                        ClassId = spellcl.CharacterClassId,
                        ClassName = cc.Name,
                        LevelForClass = spellcl.Level
                    };


            return query.ToList();
        }

        #endregion

        #region SpellsByClassAndLevel 

        public List<SpellClassLevel> Query_SpellsByClassAndLevel(string CasterClass, long CasterLevel)
        {
            var query =
                    from cc in _context.DndCharacterclass
                    join scl in _context.DndSpellclasslevel.DefaultIfEmpty() on cc.Id equals scl.CharacterClassId into spell_class_level
                    from spellcl in spell_class_level.DefaultIfEmpty()
                    join s in _context.DndSpell.DefaultIfEmpty() on spellcl.SpellId equals s.Id into sp
                    from spell in sp.DefaultIfEmpty()
                    where cc.Slug.ToLower() == CasterClass.ToLower()
                    where spellcl.Level == CasterLevel
                    select new SpellClassLevel
                    {
                        SpellId = spell.Id,
                        SpellName = spell.Name,
                        ClassId = spellcl.CharacterClassId,
                        ClassName = cc.Name,
                        LevelForClass = spellcl.Level
                    };


            return query.ToList();
        }

        public List<SpellClassLevel> Query_ClassAndLevelBySpell(long SpellId)
        {
            var query =
                    from spellclasslevel in _context.DndSpellclasslevel
                    join cc in _context.DndCharacterclass.DefaultIfEmpty() on spellclasslevel.CharacterClassId equals cc.Id into char_class
                    from characterclass in char_class.DefaultIfEmpty()
                    where spellclasslevel.SpellId == SpellId
                    select new SpellClassLevel
                    {
                        SpellId = spellclasslevel.SpellId,
                        ClassId = spellclasslevel.CharacterClassId,
                        LevelForClass = spellclasslevel.Level,
                        ClassName = characterclass.Name
                    };

            return query.ToList();
        }

        public List<SpellClassLevel> ClassAndLevelBySpell(long spellId)
        {
            Console.WriteLine(string.Format("log - ClassAndLevelBySpell - PARAMS {0}", spellId.ToString()));

            var query = Query_ClassAndLevelBySpell(spellId);

            if (query != null) {
                Console.WriteLine(string.Format("log - ClassAndLevelBySpell - ByClassAndLevel results {0}", query.Count()));
                return query;
            };

            Console.WriteLine(string.Format("log - ClassAndLevelBySpell - Not Spells Found"));
            return null;
        }
        #endregion

        #region Spell School

        /// <summary>
        /// Returns a list of spell schools for a spell, given the spell slug
        /// </summary>
        /// <param name="slug">slug of a spell</param>
        /// <returns>a list of SpellSchoolSubShool objects</returns>
        public List<DndSpellschool> Query_schoolsBySlug(string slug)
        {
            //Couldn't get these to work right in 1 query, tried many approaches.
            // spell.schoolId is a long, and not nullable, so no null checked needed here.
            var SchoolQuery =
                from spell in _context.DndSpell
                join school in _context.DndSpellschool on spell.SchoolId equals school.Id into s
                from spellschool in s.DefaultIfEmpty()
                where spell.Slug.ToLower() == slug.ToLower()
                select spellschool;

            //subschoolId is nullable, so need to check for nulls, with the where, we get an empty set, which is better then a null value in a list.
            var SubSchoolQuery =
                from spell in _context.DndSpell
                join school in _context.DndSpellschool on spell.SubSchoolId equals school.Id into s
                from spellschool in s.DefaultIfEmpty()
                where spell.Slug.ToLower() == slug.ToLower()
                where spell.SubSchoolId != null
                select spellschool;

            // combine the two queries.
            var returnList = SchoolQuery.Concat(SubSchoolQuery);

            return returnList.ToList();
        }

        /// <summary>
        /// Returns a list of spell schools for a spell, given the spell slug
        /// </summary>
        /// <param name="name">Name of a spell</param>
        /// <returns>a list of SpellSchoolSubShool objects</returns>

        public List<DndSpellschool> Query_schoolsByName(string Name)
        {
            //Couldn't get these to work right in 1 query, tried many approaches.
            // spell.schoolId is a long, and not nullable, so no null checked needed here.
            var SchoolQuery =
                from spell in _context.DndSpell
                join school in _context.DndSpellschool on spell.SchoolId equals school.Id into s
                from spellschool in s.DefaultIfEmpty()
                where spell.Name.ToLower() == Name.ToLower()
                select spellschool;

            //subschoolId is nullable, so need to check for nulls, with the where, we get an empty set, which is better then a null value in a list.
            var SubSchoolQuery =
                from spell in _context.DndSpell
                join school in _context.DndSpellschool on spell.SubSchoolId equals school.Id into s
                from spellschool in s.DefaultIfEmpty()
                where spell.Name.ToLower() == Name.ToLower()
                where spell.SubSchoolId != null
                select spellschool;

            // combine the two queries.
            var returnList = SchoolQuery.Concat(SubSchoolQuery);

            return returnList.ToList();
        }

        /// <summary>
        /// Retruns a list of spell schools by spell ID
        /// </summary>
        /// <param name="spellId">the LONG spell ID</param>
        /// <returns>a list of SpellSchooLSubSchool</returns>
        public List<DndSpellschool> Query_schoolsById(long spellId)
        {
            //Couldn't get these to work right in 1 query, tried many approaches.
            // spell.schoolId is a long, and not nullable, so no null checked needed here.
            var SchoolQuery =
                from spell in _context.DndSpell
                join school in _context.DndSpellschool on spell.SchoolId equals school.Id into s
                from spellschool in s.DefaultIfEmpty()
                where spell.Id == spellId
                select spellschool;

            //subschoolId is nullable, so need to check for nulls, with the where, we get an empty set, which is better then a null value in a list.
            var SubSchoolQuery =
                from spell in _context.DndSpell
                join school in _context.DndSpellschool on spell.SubSchoolId equals school.Id into s
                from spellschool in s.DefaultIfEmpty()
                where spell.Id == spellId
                where spell.SubSchoolId != null
                select spellschool;

            // combine the two queries.
            var returnList = SchoolQuery.Concat(SubSchoolQuery);

            return returnList.ToList();
        }

        #endregion
    }
}
