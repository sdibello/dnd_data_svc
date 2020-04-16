using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndFeatFeatCategories
    {
        public long Id { get; set; }
        public long FeatId { get; set; }
        public long FeatcategoryId { get; set; }

        public virtual DndFeat Feat { get; set; }
        public virtual DndFeatcategory Featcategory { get; set; }
    }
}
