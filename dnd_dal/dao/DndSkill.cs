using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndSkill
    {
        public DndSkill()
        {
            DndCharacterclassvariantClassSkills = new HashSet<DndCharacterclassvariantClassSkills>();
            DndCharacterclassvariantrequiresskill = new HashSet<DndCharacterclassvariantrequiresskill>();
            DndFeatrequiresskill = new HashSet<DndFeatrequiresskill>();
            DndMonsterhasskill = new HashSet<DndMonsterhasskill>();
            DndSkillvariant = new HashSet<DndSkillvariant>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string BaseSkill { get; set; }
        public long TrainedOnly { get; set; }
        public long ArmorCheckPenalty { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<DndCharacterclassvariantClassSkills> DndCharacterclassvariantClassSkills { get; set; }
        public virtual ICollection<DndCharacterclassvariantrequiresskill> DndCharacterclassvariantrequiresskill { get; set; }
        public virtual ICollection<DndFeatrequiresskill> DndFeatrequiresskill { get; set; }
        public virtual ICollection<DndMonsterhasskill> DndMonsterhasskill { get; set; }
        public virtual ICollection<DndSkillvariant> DndSkillvariant { get; set; }
    }
}
