using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndMonsterspeed
    {
        public long Id { get; set; }
        public long RaceId { get; set; }
        public long TypeId { get; set; }
        public long Speed { get; set; }

        public virtual DndMonster Race { get; set; }
        public virtual DndRacespeedtype Type { get; set; }
    }
}
