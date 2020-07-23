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

        public List<SpellSchoolSubSchool> getSchools(string spell)
        {
            Console.WriteLine(string.Format("log - SpellQuery - SchoolBySpell - PARAMS {0}", spell));
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
                    Console.WriteLine(string.Format("log - SpellQuery - SchoolBySpell - results {0}", data.Count()));

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
    }
}
