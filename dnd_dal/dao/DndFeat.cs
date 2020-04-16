using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndFeat
    {
        public DndFeat()
        {
            DndCharacterclassvariantrequiresfeat = new HashSet<DndCharacterclassvariantrequiresfeat>();
            DndFeatFeatCategories = new HashSet<DndFeatFeatCategories>();
            DndFeatrequiresfeatRequiredFeat = new HashSet<DndFeatrequiresfeat>();
            DndFeatrequiresfeatSourceFeat = new HashSet<DndFeatrequiresfeat>();
            DndFeatrequiresskill = new HashSet<DndFeatrequiresskill>();
            DndFeatspecialfeatprerequisite = new HashSet<DndFeatspecialfeatprerequisite>();
            DndItemRequiredFeats = new HashSet<DndItemRequiredFeats>();
            DndMonsterhasfeat = new HashSet<DndMonsterhasfeat>();
            DndTextfeatprerequisite = new HashSet<DndTextfeatprerequisite>();
        }

        public long Id { get; set; }
        public long RulebookId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Benefit { get; set; }
        public string Special { get; set; }
        public string Normal { get; set; }
        public long? Page { get; set; }
        public string Slug { get; set; }
        public string DescriptionHtml { get; set; }
        public string BenefitHtml { get; set; }
        public string SpecialHtml { get; set; }
        public string NormalHtml { get; set; }

        public virtual DndRulebook Rulebook { get; set; }
        public virtual ICollection<DndCharacterclassvariantrequiresfeat> DndCharacterclassvariantrequiresfeat { get; set; }
        public virtual ICollection<DndFeatFeatCategories> DndFeatFeatCategories { get; set; }
        public virtual ICollection<DndFeatrequiresfeat> DndFeatrequiresfeatRequiredFeat { get; set; }
        public virtual ICollection<DndFeatrequiresfeat> DndFeatrequiresfeatSourceFeat { get; set; }
        public virtual ICollection<DndFeatrequiresskill> DndFeatrequiresskill { get; set; }
        public virtual ICollection<DndFeatspecialfeatprerequisite> DndFeatspecialfeatprerequisite { get; set; }
        public virtual ICollection<DndItemRequiredFeats> DndItemRequiredFeats { get; set; }
        public virtual ICollection<DndMonsterhasfeat> DndMonsterhasfeat { get; set; }
        public virtual ICollection<DndTextfeatprerequisite> DndTextfeatprerequisite { get; set; }
    }
}
