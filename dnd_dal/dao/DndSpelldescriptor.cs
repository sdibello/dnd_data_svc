using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndSpelldescriptor
    {
        public DndSpelldescriptor()
        {
            DndSpellDescriptors = new HashSet<DndSpellDescriptors>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public virtual ICollection<DndSpellDescriptors> DndSpellDescriptors { get; set; }
    }
}
