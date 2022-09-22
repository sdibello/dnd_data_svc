using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndItemRequiredFeats
    {
        public long Id { get; set; }
        public long ItemId { get; set; }
        public long FeatId { get; set; }

        public virtual DndFeat Feat { get; set; }
        public virtual DndItem Item { get; set; }
    }
}
