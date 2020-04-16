using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndSpelldomainlevel
    {
        public long Id { get; set; }
        public long DomainId { get; set; }
        public long SpellId { get; set; }
        public long Level { get; set; }
        public string Extra { get; set; }

        public virtual DndDomain Domain { get; set; }
        public virtual DndSpell Spell { get; set; }
    }
}
