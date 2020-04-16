using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndItem
    {
        public DndItem()
        {
            DndDeity = new HashSet<DndDeity>();
            DndItemAuraSchools = new HashSet<DndItemAuraSchools>();
            DndItemRequiredFeats = new HashSet<DndItemRequiredFeats>();
            DndItemRequiredSpells = new HashSet<DndItemRequiredSpells>();
            InverseSynergyPrerequisite = new HashSet<DndItem>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public long RulebookId { get; set; }
        public long? Page { get; set; }
        public long? PriceGp { get; set; }
        public long? PriceBonus { get; set; }
        public long? ItemLevel { get; set; }
        public long? BodySlotId { get; set; }
        public long? CasterLevel { get; set; }
        public long? AuraId { get; set; }
        public string AuraDc { get; set; }
        public long? ActivationId { get; set; }
        public double? Weight { get; set; }
        public string VisualDescription { get; set; }
        public string Description { get; set; }
        public string DescriptionHtml { get; set; }
        public string Type { get; set; }
        public long? PropertyId { get; set; }
        public string CostToCreate { get; set; }
        public long? SynergyPrerequisiteId { get; set; }
        public string RequiredExtra { get; set; }

        public virtual DndItemactivationtype Activation { get; set; }
        public virtual DndItemauratype Aura { get; set; }
        public virtual DndItemslot BodySlot { get; set; }
        public virtual DndItemproperty Property { get; set; }
        public virtual DndRulebook Rulebook { get; set; }
        public virtual DndItem SynergyPrerequisite { get; set; }
        public virtual ICollection<DndDeity> DndDeity { get; set; }
        public virtual ICollection<DndItemAuraSchools> DndItemAuraSchools { get; set; }
        public virtual ICollection<DndItemRequiredFeats> DndItemRequiredFeats { get; set; }
        public virtual ICollection<DndItemRequiredSpells> DndItemRequiredSpells { get; set; }
        public virtual ICollection<DndItem> InverseSynergyPrerequisite { get; set; }
    }
}
