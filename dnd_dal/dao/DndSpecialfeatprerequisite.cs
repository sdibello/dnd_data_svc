using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndSpecialfeatprerequisite
    {
        public DndSpecialfeatprerequisite()
        {
            DndFeatspecialfeatprerequisite = new HashSet<DndFeatspecialfeatprerequisite>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string PrintFormat { get; set; }

        public virtual ICollection<DndFeatspecialfeatprerequisite> DndFeatspecialfeatprerequisite { get; set; }
    }
}
