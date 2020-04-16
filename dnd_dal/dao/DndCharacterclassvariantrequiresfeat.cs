using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndCharacterclassvariantrequiresfeat
    {
        public long Id { get; set; }
        public long CharacterClassVariantId { get; set; }
        public long FeatId { get; set; }
        public string Extra { get; set; }
        public string TextBefore { get; set; }
        public string TextAfter { get; set; }
        public long RemoveComma { get; set; }

        public virtual DndCharacterclassvariant CharacterClassVariant { get; set; }
        public virtual DndFeat Feat { get; set; }
    }
}
