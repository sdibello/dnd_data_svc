using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndRacespeedtype
    {
        public DndRacespeedtype()
        {
            DndMonsterspeed = new HashSet<DndMonsterspeed>();
            DndRacespeed = new HashSet<DndRacespeed>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Extra { get; set; }

        public virtual ICollection<DndMonsterspeed> DndMonsterspeed { get; set; }
        public virtual ICollection<DndRacespeed> DndRacespeed { get; set; }
    }
}
