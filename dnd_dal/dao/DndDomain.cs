using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndDomain
    {
        public DndDomain()
        {
            DndDomainvariant = new HashSet<DndDomainvariant>();
            DndSpelldomainlevel = new HashSet<DndSpelldomainlevel>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<DndDomainvariant> DndDomainvariant { get; set; }
        public virtual ICollection<DndSpelldomainlevel> DndSpelldomainlevel { get; set; }
    }
}
