using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndMonsterhasskill
    {
        public long Id { get; set; }
        public long MonsterId { get; set; }
        public long SkillId { get; set; }
        public long Ranks { get; set; }
        public string Extra { get; set; }

        public virtual DndMonster Monster { get; set; }
        public virtual DndSkill Skill { get; set; }
    }
}
