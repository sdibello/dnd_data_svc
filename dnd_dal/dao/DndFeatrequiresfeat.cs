using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndFeatrequiresfeat
    {
        public long Id { get; set; }
        public long SourceFeatId { get; set; }
        public long RequiredFeatId { get; set; }
        public string AdditionalText { get; set; }

        public virtual DndFeat RequiredFeat { get; set; }
        public virtual DndFeat SourceFeat { get; set; }
    }
}
