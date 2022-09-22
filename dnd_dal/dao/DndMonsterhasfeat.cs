using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndMonsterhasfeat
    {
        public long Id { get; set; }
        public long MonsterId { get; set; }
        public long FeatId { get; set; }
        public string Extra { get; set; }

        public virtual DndFeat Feat { get; set; }
        public virtual DndMonster Monster { get; set; }
    }
}
