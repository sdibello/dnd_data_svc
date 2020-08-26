﻿using System;
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
            List<DndSpell> spellResult = null;

            try
            {
                List<DndSpellschool> data;
                // get the spell #refactor
                if (long.TryParse(spell, out long longId))
                {
                    spellResult = sq.Query_dndSpellByID(longId).ToList();
                }
                else
                {
                    if (HttpUtility.UrlDecode(spell).IndexOf(' ') > 0)
                    {
                        spellResult = sq.Query_dndSpellByName(spell).ToList();
                    }
                    else
                    {
                        spellResult = sq.Query_dndSpellBySlug(spell).ToList();
                    }
                }

                if (spellResult != null) {
                    Console.WriteLine(string.Format("log - getSchools - getSchools - results {0}", spellResult.Count()));

                    foreach (var s in spellResult)
                    {
                        var primary = sq.Query_dndSpellSchoolByID(s.SchoolId);

                        result.Add(new SpellSchoolSubSchool
                        {
                            isPrimary = true,
                            SchoolId = s.SchoolId,
                            SchoolName = primary[0].Name,
                        });

                        if ( s.SubSchoolId!= null) {
                            var secondary = sq.Query_dndSpellSchoolByID((long)s.SubSchoolId);
                            result.Add(new SpellSchoolSubSchool
                            {
                                isPrimary = false,
                                SchoolId = s.SubSchoolId,
                                SchoolName = secondary[0].Name,
                            });
                        }
                    }

                };
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        public List<SpellCL> getClass(string spell)
        {
            Console.WriteLine(string.Format("log - SpellQuery - getClass - PARAMS {0}", spell));
            SpellQuery sq = new SpellQuery(this.dbcontext);
            List<dnd_dal.DndSpell> spellResult = new List<dnd_dal.DndSpell>();
            List<SpellCL> data = new List<SpellCL>();

            try
            {
                // get the spell #refactor
                if (long.TryParse(spell, out long longId))
                {
                    spellResult = sq.Query_dndSpellByID(longId);
                }
                else
                {
                    if (HttpUtility.UrlDecode(spell).IndexOf(' ') > 0)
                    {
                        spellResult = sq.Query_dndSpellByName(spell);
                    } else {
                        spellResult = sq.Query_dndSpellBySlug(spell);
                    }
                }

                if (spellResult.Count > 0)
                {
                    Console.WriteLine(string.Format("log - SpellQuery - getClass - results {0}", spellResult.Count()));
                    var spellID = spellResult.First().Id;

                    var SpellClassLevel = sq.Query_dndSpellClassLevelBySpellId(spellID);

                    var CharacterClassIds = SpellClassLevel.Select(x => x.CharacterClassId).ToList();

                    var final = sq.Query_dndCharacterClassByIds(CharacterClassIds);

                    foreach (var item in SpellClassLevel)
                    {
                        // create spellCL with the data from the last to gets.
                        data.Add(new SpellCL
                        {
                            SpellId = spellResult.First().Id,
                            SpellName = spellResult.First().Name,
                            ClassId = item.CharacterClassId,
                            ClassName = final.Where(x => x.Id == item.CharacterClassId).First().Name,
                            Level = item.Level
                        });
                    }


                    if (data.Count == 0)
                        return null;
                    return data;
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