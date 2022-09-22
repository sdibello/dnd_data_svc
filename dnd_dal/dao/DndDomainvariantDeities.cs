using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndDomainvariantDeities
    {
        public long Id { get; set; }
        public long DomainvariantId { get; set; }
        public long DeityId { get; set; }

        public virtual DndDeity Deity { get; set; }
        public virtual DndDomainvariant Domainvariant { get; set; }
    }
}
