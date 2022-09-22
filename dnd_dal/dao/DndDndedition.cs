using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndDndedition
    {
        public DndDndedition()
        {
            DndRulebook = new HashSet<DndRulebook>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string System { get; set; }
        public string Slug { get; set; }
        public long Core { get; set; }

        public virtual ICollection<DndRulebook> DndRulebook { get; set; }
    }
}
