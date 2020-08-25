using System;
using System.Collections.Generic;
using System.Text;
using dnd_dal;
using dnd_dal.query.spell;
using System.Linq;
using System.Web;
using dnd_service_logic.dto;

namespace dnd_service_logic.BL
{
    public class SpellLogic : BaseLogic 
    {
        public SpellLogic(dndContext databaseContext)
        {
            base.dbcontext = databaseContext;
        }

        /// <summary>
        ///   Pull a list of "SpellClassLewvels items from the database, which lists all spells by class level.
        /// </summary>
        /// <param name="context">Database Concept</param>
        /// <param name="CasterClass">string value of the character class</param>
        /// <param name="CasterLevel">string value of the character level</param>
        /// <returns>A list of SpellClassLevels </returns>
        public List<SpellCL> getSpellsByClassAndLevel(string CasterClass, string CasterLevel)
        {
            long level;
            SpellQuery sq = new SpellQuery(this.dbcontext);

            Console.WriteLine(string.Format("log - SpellQuery - SpellsByClassAndLevel - ByClassAndLevel PARAMS {0} {1}", CasterClass, CasterLevel));

            if (long.TryParse(CasterLevel, out level))
            {
                var query = sq.Query_SpellsByClassAndLevel(CasterClass, level).ToList();
                List<SpellCL> data = new List<SpellCL>();

                foreach (var item in query.ToList())
                {
                    SpellCL i = new SpellCL();
                    i.ClassId = item.ClassId;
                    i.ClassName = item.ClassName;
                    i.Level = item.LevelForClass;
                    i.SpellId = item.SpellId;
                    i.SpellName = item.SpellName;
                    data.Add(i);
                }

                if (query != null)
                {
                    Console.WriteLine(string.Format("log - SpellQuery - SpellsByClassAndLevel - ByClassAndLevel - ByClassAndLevel results {0}", query.Count()));
                    return data;
                };
            }

            Console.WriteLine(string.Format("log - SpellQuery - SpellsByClassAndLevel - ByClassAndLevel - Not Spells Found", CasterClass, CasterLevel));
            return null;
        }

        /// <summary>
        /// Gets the primary and sub school for a given spell.
        /// </summary>
        /// <param name="spell">Can be the ID, the slug, or the name of the spell</param>
        /// <returns></returns>
        public List<SpellSchoolSubSchool> getSchools(string spell)
        {
            Console.WriteLine(string.Format("log - SpellQuery - getSchools - PARAMS {0}", spell));
            SpellQuery sq = new SpellQuery(this.dbcontext);
            List<SpellSchoolSubSchool> result = new List<SpellSchoolSubSchool>();

            try
            {
                List<DndSpellschool> data;
                if (long.TryParse(spell, out long longId))
                {
                    data = sq.Query_schoolsById(longId);
                }
                else
                {
                    if (HttpUtility.UrlDecode(spell).IndexOf(' ') > 0) {
                    data = sq.Query_schoolsByName(spell);
                    } else {
                    data = sq.Query_schoolsBySlug(spell);
                    }
                }

                if (data != null) {
                    Console.WriteLine(string.Format("log - SpellQuery - getSchools - results {0}", data.Count()));

                    //TODO - automapper here.

                    foreach (var dndss in data) {
                        var item = new SpellSchoolSubSchool {
                            SchoolId = dndss.Id,
                            SchoolName = dndss.Name
                        };
                        result.Add(item);
                    }
                    return result;
                };
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

        public List<SpellSchoolSubSchool> getClass(string spell)
        {
            Console.WriteLine(string.Format("log - SpellQuery - getClass - PARAMS {0}", spell));
            SpellQuery sq = new SpellQuery(this.dbcontext);
            List<dnd_dal.DndSpell> result = new List<dnd_dal.DndSpell>();

            try
            {
                List<DndSpellschool> data;
                if (long.TryParse(spell, out long longId))
                {
                    result = sq.Query_dndSpellByID(longId);
                }
                else
                {
                    if (HttpUtility.UrlDecode(spell).IndexOf(' ') > 0)
                    {
                        result = sq.Query_dndSpellByName(spell);
                    }
                    else
                    {
                        result = sq.Query_dndSpellBySlug(spell);
                    }
                }

                // use the spell id here to get the dnd_spellclasslevel

                // user the dnd_spellclasslevel  to pull all the dnd_characterclass

                if (result.Count > 0)
                {
                    Console.WriteLine(string.Format("log - SpellQuery - getClass - results {0}", result.Count()));

                    //TODO - automapper here.

                    foreach (var dndss in data)
                    {
                        var item = new SpellSchoolSubSchool
                        {
                            SchoolId = dndss.Id,
                            SchoolName = dndss.Name
                        };
                        result.Add(item);
                    }
                    return result;
                };
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }

    }
}
