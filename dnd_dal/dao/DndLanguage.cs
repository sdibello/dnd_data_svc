using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndLanguage
    {
        public DndLanguage()
        {
            DndRaceAutomaticLanguages = new HashSet<DndRaceAutomaticLanguages>();
            DndRaceBonusLanguages = new HashSet<DndRaceBonusLanguages>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string DescriptionHtml { get; set; }

        public virtual ICollection<DndRaceAutomaticLanguages> DndRaceAutomaticLanguages { get; set; }
        public virtual ICollection<DndRaceBonusLanguages> DndRaceBonusLanguages { get; set; }
    }
}
