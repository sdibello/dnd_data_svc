using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndRacefavoredcharacterclass
    {
        public long Id { get; set; }
        public long RaceId { get; set; }
        public long CharacterClassId { get; set; }
        public string Extra { get; set; }

        public virtual DndCharacterclass CharacterClass { get; set; }
        public virtual DndRace Race { get; set; }
    }
}
