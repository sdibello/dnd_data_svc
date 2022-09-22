using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndMonstersubtype
    {
        public DndMonstersubtype()
        {
            DndMonsterSubtypes = new HashSet<DndMonsterSubtypes>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<DndMonsterSubtypes> DndMonsterSubtypes { get; set; }
    }
}
