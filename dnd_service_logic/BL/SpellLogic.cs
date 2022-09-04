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
            SpellQuery sq = new();

            Console.WriteLine(string.Format("log - SpellQuery - SpellsByClassAndLevel - ByClassAndLevel PARAMS {0} {1}", CasterClass, CasterLevel));

            if (long.TryParse(CasterLevel, out level))
            {
                //Get Class and Level data from the database.
                var query = sq.Query_SpellsByClassAndLevel(CasterClass, level).ToList();
                List<SpellCL> data = new();

                //Format the data from the query into a DTO and pass.
                foreach (var item in query.ToList())
                {
                    SpellCL i = new();
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
            SpellQuery sq = new();
            List<SpellSchoolSubSchool> result = new();
            List<DndSpell> spellResult = null;

            try
            {
                spellResult = getDBSpell(spell);

                if (spellResult != null) {
                    Console.WriteLine(string.Format("log - getSchools - getSchools - results {0}", spellResult.Count()));

                    foreach (var s in spellResult)
                    {
                        var primary = sq.Query_dndSpellSchoolByID(s.SchoolId);

                        result.Add(new SpellSchoolSubSchool
                        {
                            SpellId = s.Id,
                            Spellname = s.Name,
                            isPrimary = true,
                            SchoolId = s.SchoolId,
                            SchoolName = primary[0].Name,
                        });

                        if ( s.SubSchoolId!= null) {
                            var secondary = sq.Query_dndSpellSchoolByID((long)s.SubSchoolId);
                            result.Add(new SpellSchoolSubSchool
                            {
                                SpellId = s.Id,
                                Spellname = s.Name,
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

        public List<DndSpell> getDBSpell(string spell)
        {
            List<DndSpell> spelldb;
            SpellQuery sq = new();
            // get the spell #refactor
            if (long.TryParse(spell, out long longId))
            {
                spelldb = sq.Query_dndSpellByID(longId);
            }
            else
            {
                if (HttpUtility.UrlDecode(spell).IndexOf(' ') > 0)
                {
                    spelldb = sq.Query_dndSpellByName(spell);
                }
                else
                {
                    spelldb = sq.Query_dndSpellBySlug(spell);
                }
            }
            return spelldb;
        }

        public List<SpellCL> getClass(string spell)
        {
            Console.WriteLine(string.Format("log - SpellQuery - getClass - PARAMS {0}", spell));
            SpellQuery sq = new();
            List<dnd_dal.DndSpell> spellResult = new();
            List<SpellCL> data = new();

            try
            {
                spellResult = getDBSpell(spell);

                if (spellResult.Count > 0)
                {
                    Console.WriteLine(string.Format("log - SpellQuery - getClass - results {0}", spellResult.Count()));
                    foreach (var s in spellResult)
                    {
                        var spellID = s.Id;
                        var scl = sq.Query_dndSpellClassLevelBySpellId(spellID);
                        var CharacterClassIds = scl.Select(x => x.CharacterClassId).ToList();
                        var final = sq.Query_dndCharacterClassByIds(CharacterClassIds);

                        foreach (var item in scl)
                        {
                            // create spellCL with the data from the last two gets.
                            data.Add(new SpellCL
                            {
                                SpellId = s.Id,
                                SpellName = spellResult.First().Name,
                                ClassId = item.CharacterClassId,
                                ClassName = final.Where(x => x.Id == item.CharacterClassId).First().Name,
                                Level = item.Level
                            });
                        }

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

        public List<Spell> getSpells(string spell)
        {
            List<DndSpell> spelldb;
            List<Spell> result =  new();

            spelldb = getDBSpell(spell);

            if (spelldb != null)
            {
                if (spelldb.Count > 0)
                {
                    foreach (var s in spelldb)
                    {
                        result.Add(new Spell
                        {
                            Id = s.Id,
                            Description = s.Description,
                            Name = s.Name,
                            CastingTime = s.CastingTime,
                            Range = s.Range,
                            SavingThrow = s.SavingThrow,
                            SpellResistance = s.SpellResistance,
                            Duration = s.Duration,
                            Target = s.Target,
                            Slug = s.Slug,
                            SubSchoolId = s.SubSchoolId,
                            SchoolId = s.SchoolId,
                            ArcaneFocusComponent = s.ArcaneFocusComponent,
                            DivineFocusComponent = s.DivineFocusComponent,
                            MaterialComponent = s.MaterialComponent,
                            SomaticComponent = s.SomaticComponent,
                            VerbalComponent = s.VerbalComponent,
                            XpComponent = s.XpComponent,
                            RulebookId = s.RulebookId
                        });
                    }
                    return result;
                }
                else
                {
                    Console.WriteLine(string.Format("log - get spell - ({0}), WARN not found", spell));
                    return result;
                };
            }

            Console.WriteLine(string.Format("log - get spell - ({0}), ERROR should not have gotten here.", spell));
            return null;
        }

    }
}
