using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndRacespeed
    {
        public long Id { get; set; }
        public long TypeId { get; set; }
        public long Speed { get; set; }
        public long RaceId { get; set; }

        public virtual DndRace Race { get; set; }
        public virtual DndRacespeedtype Type { get; set; }
    }
}
