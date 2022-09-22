using System;
using System.Collections.Generic;
using System.Text;
using dnd_dal.query.CharacterClass;
using System.Linq;
using System.Web;
using dnd_service_logic.dto;
using dnd_dal.query.spell;
using dnd_dal.dao;

namespace dnd_service_logic.BL
{
    public class ClassLogic : BaseLogic
    {
        public List<DndCharacterclass> getDBClass(string classParam)
        {
            List<DndCharacterclass> classdb;
            CharacterClassQuery ccq = new CharacterClassQuery();
            // get the spell #refactor
            if (long.TryParse(classParam, out long longId))
            {
                classdb = ccq.Query_GetCharacterClassById(longId);
            }
            else
            {
                if (HttpUtility.UrlDecode(classParam).IndexOf(' ') > 0)
                {
                    classdb = ccq.Query_GetCharacterClassBySlug(classParam);
                } else {
                    classdb = ccq.Query_GetCharacterClassByName(classParam);
                }
            }

            return classdb;
        }

        public List<ClassSpell> getclassSpells(string classParam)
        {
            List<DndCharacterclass> classdb;
            CharacterClassQuery ccq = new CharacterClassQuery();
            SpellQuery sq = new SpellQuery();
            List<ClassSpell> result = new List<ClassSpell>();

            var charaters = getDBClass(classParam);

            foreach (var dd in charaters)
            {
                var classId = dd.Id;
                var scl = ccq.Query_GetCharacterClassSpellLevel(classId);

                foreach (var classlevel in scl)
                {
                    var spell = sq.Query_dndSpellByID(classlevel.SpellId).First();
                    ClassSpell cs = new ClassSpell
                    {
                        ClassId = dd.Id,
                        ClassName = dd.Name,
                        Level = classlevel.Level,
                        SpellId = classlevel.SpellId,
                        SpellName = spell.Name
                    };
                    result.Add(cs);
                }
            }

            return result;
        }
    }
}
