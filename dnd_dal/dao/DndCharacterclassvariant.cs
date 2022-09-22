using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndCharacterclassvariant
    {
        public DndCharacterclassvariant()
        {
            DndCharacterclassvariantClassSkills = new HashSet<DndCharacterclassvariantClassSkills>();
            DndCharacterclassvariantrequiresfeat = new HashSet<DndCharacterclassvariantrequiresfeat>();
            DndCharacterclassvariantrequiresrace = new HashSet<DndCharacterclassvariantrequiresrace>();
            DndCharacterclassvariantrequiresskill = new HashSet<DndCharacterclassvariantrequiresskill>();
        }

        public long Id { get; set; }
        public long CharacterClassId { get; set; }
        public long RulebookId { get; set; }
        public long? Page { get; set; }
        public string Advancement { get; set; }
        public string AdvancementHtml { get; set; }
        public string ClassFeatures { get; set; }
        public long? SkillPoints { get; set; }
        public long? HitDie { get; set; }
        public string Alignment { get; set; }
        public string ClassFeaturesHtml { get; set; }
        public string Requirements { get; set; }
        public string RequirementsHtml { get; set; }
        public long? RequiredBab { get; set; }
        public string StartingGold { get; set; }

        public virtual DndCharacterclass CharacterClass { get; set; }
        public virtual DndRulebook Rulebook { get; set; }
        public virtual ICollection<DndCharacterclassvariantClassSkills> DndCharacterclassvariantClassSkills { get; set; }
        public virtual ICollection<DndCharacterclassvariantrequiresfeat> DndCharacterclassvariantrequiresfeat { get; set; }
        public virtual ICollection<DndCharacterclassvariantrequiresrace> DndCharacterclassvariantrequiresrace { get; set; }
        public virtual ICollection<DndCharacterclassvariantrequiresskill> DndCharacterclassvariantrequiresskill { get; set; }
    }
}
