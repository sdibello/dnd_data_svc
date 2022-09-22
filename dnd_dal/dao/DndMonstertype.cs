using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndMonstertype
    {
        public DndMonstertype()
        {
            DndMonster = new HashSet<DndMonster>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<DndMonster> DndMonster { get; set; }
    }
}
