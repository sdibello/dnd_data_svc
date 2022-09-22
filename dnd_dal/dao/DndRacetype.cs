using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndRacetype
    {
        public DndRacetype()
        {
            DndRace = new HashSet<DndRace>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public long HitDieSize { get; set; }
        public string BaseAttackType { get; set; }
        public string BaseFortSaveType { get; set; }
        public string BaseReflexSaveType { get; set; }
        public string BaseWillSaveType { get; set; }

        public virtual ICollection<DndRace> DndRace { get; set; }
    }
}
