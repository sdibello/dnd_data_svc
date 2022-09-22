using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndItemAuraSchools
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public long SpellschoolId { get; set; }

        public virtual DndItem Item { get; set; }
        public virtual DndSpellschool Spellschool { get; set; }
    }
}
