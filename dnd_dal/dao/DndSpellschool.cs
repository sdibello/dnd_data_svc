using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndSpellschool
    {
        public DndSpellschool()
        {
            DndItemAuraSchools = new HashSet<DndItemAuraSchools>();
            DndSpell = new HashSet<DndSpell>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<DndItemAuraSchools> DndItemAuraSchools { get; set; }
        public virtual ICollection<DndSpell> DndSpell { get; set; }
    }
}
