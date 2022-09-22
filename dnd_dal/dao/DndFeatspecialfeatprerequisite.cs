using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndFeatspecialfeatprerequisite
    {
        public long Id { get; set; }
        public long FeatId { get; set; }
        public long SpecialFeatPrerequisiteId { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }

        public virtual DndFeat Feat { get; set; }
        public virtual DndSpecialfeatprerequisite SpecialFeatPrerequisite { get; set; }
    }
}
