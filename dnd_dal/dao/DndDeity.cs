using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndDeity
    {
        public DndDeity()
        {
            DndDomainvariantDeities = new HashSet<DndDomainvariantDeities>();
            DndDomainvariantOtherDeities = new HashSet<DndDomainvariantOtherDeities>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string DescriptionHtml { get; set; }
        public string Alignment { get; set; }
        public long? FavoredWeaponId { get; set; }

        public virtual DndItem FavoredWeapon { get; set; }
        public virtual ICollection<DndDomainvariantDeities> DndDomainvariantDeities { get; set; }
        public virtual ICollection<DndDomainvariantOtherDeities> DndDomainvariantOtherDeities { get; set; }
    }
}
