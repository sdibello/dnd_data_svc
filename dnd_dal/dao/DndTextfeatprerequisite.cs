using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndTextfeatprerequisite
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public long FeatId { get; set; }

        public virtual DndFeat Feat { get; set; }
    }
}
