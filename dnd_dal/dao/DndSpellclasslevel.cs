using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndSpellclasslevel
    {
        public long Id { get; set; }
        public long CharacterClassId { get; set; }
        public long SpellId { get; set; }
        public long Level { get; set; }
        public string Extra { get; set; }

        public virtual DndCharacterclass CharacterClass { get; set; }
        public virtual DndSpell Spell { get; set; }
    }
}
