using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndCharacterclassvariantClassSkills
    {
        public long Id { get; set; }
        public long CharacterclassvariantId { get; set; }
        public long SkillId { get; set; }

        public virtual DndCharacterclassvariant Characterclassvariant { get; set; }
        public virtual DndSkill Skill { get; set; }
    }
}
