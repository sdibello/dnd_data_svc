using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndFeatrequiresskill
    {
        public long Id { get; set; }
        public long FeatId { get; set; }
        public long SkillId { get; set; }
        public long MinRank { get; set; }
        public string Extra { get; set; }

        public virtual DndFeat Feat { get; set; }
        public virtual DndSkill Skill { get; set; }
    }
}
