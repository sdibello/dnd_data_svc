using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using dnd_dal.dao;

namespace dnd_dal.query.CharacterClass
{
    public class CharacterClassQuery
    {

        private readonly dndContext _context;

        public CharacterClassQuery()
        {
        }

        /// <summary>
        /// Return the complete list of Characters Classes.
        /// </summary>
        /// <param name="CasterClass"></param>
        /// <param name="CasterLevel"></param>
        /// <returns></returns>
        public List<DndCharacterclass> Query_GetCharacterClass()
        {
            dndContext db = new dndContext();

            var query =
                    from characterclass in db.DndCharacterclass
                    select characterclass;

            return query.ToList();
        }

        public List<DndCharacterclass> Query_GetCharacterClassById(long id)
        {
            dndContext db = new dndContext();

            var query =
                    from characterclass in db.DndCharacterclass
                    where characterclass.Id == id
                    select characterclass;

            return query.ToList();
        }

        public List<DndCharacterclass> Query_GetCharacterClassByName(string name)
        {
            dndContext db = new dndContext();

            var query =
                    from characterclass in db.DndCharacterclass
                    where characterclass.Name.ToLower() == name.ToLower()
                    select characterclass;

            return query.ToList();
        }

        public List<DndCharacterclass> Query_GetCharacterClassBySlug(string slug)
        {
            dndContext db = new dndContext();

            var query =
                    from characterclass in db.DndCharacterclass
                    where characterclass.Slug == slug
                    select characterclass;

            return query.ToList();
        }

        public List<DndSpellclasslevel> Query_GetCharacterClassSpellLevel(long characterclassId)
        {
            dndContext db = new dndContext();

            var query =
                    from spellCL in db.DndSpellclasslevel
                    where spellCL.CharacterClassId == characterclassId
                    select spellCL;

            return query.ToList();
        }


    }
}
