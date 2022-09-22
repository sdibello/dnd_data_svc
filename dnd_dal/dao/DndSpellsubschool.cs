using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndSpellsubschool
    {
        public DndSpellsubschool()
        {
            DndSpell = new HashSet<DndSpell>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<DndSpell> DndSpell { get; set; }
    }
}
