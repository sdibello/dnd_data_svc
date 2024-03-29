﻿using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndCharacterclassvariantrequiresskill
    {
        public long Id { get; set; }
        public long CharacterClassVariantId { get; set; }
        public long SkillId { get; set; }
        public long Ranks { get; set; }
        public string Extra { get; set; }
        public string TextBefore { get; set; }
        public string TextAfter { get; set; }
        public long RemoveComma { get; set; }

        public virtual DndCharacterclassvariant CharacterClassVariant { get; set; }
        public virtual DndSkill Skill { get; set; }
    }
}
