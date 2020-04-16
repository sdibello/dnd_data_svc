using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndCharacterclass
    {
        public DndCharacterclass()
        {
            DndCharacterclassvariant = new HashSet<DndCharacterclassvariant>();
            DndRacefavoredcharacterclass = new HashSet<DndRacefavoredcharacterclass>();
            DndSpellclasslevel = new HashSet<DndSpellclasslevel>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public long Prestige { get; set; }
        public string ShortDescription { get; set; }
        public string ShortDescriptionHtml { get; set; }

        public virtual ICollection<DndCharacterclassvariant> DndCharacterclassvariant { get; set; }
        public virtual ICollection<DndRacefavoredcharacterclass> DndRacefavoredcharacterclass { get; set; }
        public virtual ICollection<DndSpellclasslevel> DndSpellclasslevel { get; set; }
    }
}
