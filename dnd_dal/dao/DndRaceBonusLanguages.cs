using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndRaceBonusLanguages
    {
        public long Id { get; set; }
        public long RaceId { get; set; }
        public long LanguageId { get; set; }

        public virtual DndLanguage Language { get; set; }
        public virtual DndRace Race { get; set; }
    }
}
