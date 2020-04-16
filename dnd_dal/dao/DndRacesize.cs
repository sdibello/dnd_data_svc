using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndRacesize
    {
        public DndRacesize()
        {
            DndMonster = new HashSet<DndMonster>();
            DndRace = new HashSet<DndRace>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long Order { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DndMonster> DndMonster { get; set; }
        public virtual ICollection<DndRace> DndRace { get; set; }
    }
}
