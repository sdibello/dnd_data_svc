using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndDomainvariant
    {
        public DndDomainvariant()
        {
            DndDomainvariantDeities = new HashSet<DndDomainvariantDeities>();
            DndDomainvariantOtherDeities = new HashSet<DndDomainvariantOtherDeities>();
        }

        public long Id { get; set; }
        public long DomainId { get; set; }
        public long RulebookId { get; set; }
        public long? Page { get; set; }
        public string Requirement { get; set; }
        public string GrantedPower { get; set; }
        public string GrantedPowerHtml { get; set; }
        public string GrantedPowerType { get; set; }
        public string DeitiesText { get; set; }

        public virtual DndDomain Domain { get; set; }
        public virtual DndRulebook Rulebook { get; set; }
        public virtual ICollection<DndDomainvariantDeities> DndDomainvariantDeities { get; set; }
        public virtual ICollection<DndDomainvariantOtherDeities> DndDomainvariantOtherDeities { get; set; }
    }
}
