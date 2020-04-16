using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndFeatcategory
    {
        public DndFeatcategory()
        {
            DndFeatFeatCategories = new HashSet<DndFeatFeatCategories>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<DndFeatFeatCategories> DndFeatFeatCategories { get; set; }
    }
}
