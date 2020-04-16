using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndMonsterSubtypes
    {
        public long Id { get; set; }
        public long MonsterId { get; set; }
        public long MonstersubtypeId { get; set; }

        public virtual DndMonster Monster { get; set; }
        public virtual DndMonstersubtype Monstersubtype { get; set; }
    }
}
