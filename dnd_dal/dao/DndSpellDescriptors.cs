using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndSpellDescriptors
    {
        public long Id { get; set; }
        public long SpellId { get; set; }
        public long SpelldescriptorId { get; set; }

        public virtual DndSpell Spell { get; set; }
        public virtual DndSpelldescriptor Spelldescriptor { get; set; }
    }
}
