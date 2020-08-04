using System;
using System.Collections.Generic;
using System.Text;
using dnd_dal;
using System.Linq;

namespace dnd_dal.query.CharacterClass
{
    class CharacterClassQuery
    {

        private readonly dndContext _context;

        public CharacterClassQuery(dndContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Return the complete list of Characters Classes.
        /// </summary>
        /// <param name="CasterClass"></param>
        /// <param name="CasterLevel"></param>
        /// <returns></returns>
        private List<DndCharacterclass> Query_GetCharacterClass()
        {
            var query =
                    from characterclass in _context.DndCharacterclass
                    select characterclass;

            return query.ToList();
        }
    }
}
