using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndRulebook
    {
        public DndRulebook()
        {
            DndCharacterclassvariant = new HashSet<DndCharacterclassvariant>();
            DndDomainvariant = new HashSet<DndDomainvariant>();
            DndFeat = new HashSet<DndFeat>();
            DndItem = new HashSet<DndItem>();
            DndMonster = new HashSet<DndMonster>();
            DndRace = new HashSet<DndRace>();
            DndRule = new HashSet<DndRule>();
            DndSkillvariant = new HashSet<DndSkillvariant>();
            DndSpell = new HashSet<DndSpell>();
        }

        public long Id { get; set; }
        public long DndEditionId { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
        public string OfficialUrl { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public byte[] Published { get; set; }

        public virtual DndDndedition DndEdition { get; set; }
        public virtual ICollection<DndCharacterclassvariant> DndCharacterclassvariant { get; set; }
        public virtual ICollection<DndDomainvariant> DndDomainvariant { get; set; }
        public virtual ICollection<DndFeat> DndFeat { get; set; }
        public virtual ICollection<DndItem> DndItem { get; set; }
        public virtual ICollection<DndMonster> DndMonster { get; set; }
        public virtual ICollection<DndRace> DndRace { get; set; }
        public virtual ICollection<DndRule> DndRule { get; set; }
        public virtual ICollection<DndSkillvariant> DndSkillvariant { get; set; }
        public virtual ICollection<DndSpell> DndSpell { get; set; }
    }
}
