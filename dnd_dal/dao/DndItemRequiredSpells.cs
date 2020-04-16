using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndItemRequiredSpells
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public long SpellId { get; set; }

        public virtual DndItem Item { get; set; }
        public virtual DndSpell Spell { get; set; }
    }
}
