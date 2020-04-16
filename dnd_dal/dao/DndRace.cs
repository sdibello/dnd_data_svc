using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndRace
    {
        public DndRace()
        {
            DndCharacterclassvariantrequiresrace = new HashSet<DndCharacterclassvariantrequiresrace>();
            DndRaceAutomaticLanguages = new HashSet<DndRaceAutomaticLanguages>();
            DndRaceBonusLanguages = new HashSet<DndRaceBonusLanguages>();
            DndRacefavoredcharacterclass = new HashSet<DndRacefavoredcharacterclass>();
            DndRacespeed = new HashSet<DndRacespeed>();
        }

        public long Id { get; set; }
        public long RulebookId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public long? Page { get; set; }
        public long Str { get; set; }
        public long Dex { get; set; }
        public long? Con { get; set; }
        public long Int { get; set; }
        public long Wis { get; set; }
        public long Cha { get; set; }
        public long LevelAdjustment { get; set; }
        public long SizeId { get; set; }
        public long Space { get; set; }
        public long Reach { get; set; }
        public string Combat { get; set; }
        public string Description { get; set; }
        public string RacialTraits { get; set; }
        public string DescriptionHtml { get; set; }
        public string CombatHtml { get; set; }
        public string RacialTraitsHtml { get; set; }
        public long? NaturalArmor { get; set; }
        public string Image { get; set; }
        public long? RaceTypeId { get; set; }
        public long? RacialHitDiceCount { get; set; }

        public virtual DndRacetype RaceType { get; set; }
        public virtual DndRulebook Rulebook { get; set; }
        public virtual DndRacesize Size { get; set; }
        public virtual ICollection<DndCharacterclassvariantrequiresrace> DndCharacterclassvariantrequiresrace { get; set; }
        public virtual ICollection<DndRaceAutomaticLanguages> DndRaceAutomaticLanguages { get; set; }
        public virtual ICollection<DndRaceBonusLanguages> DndRaceBonusLanguages { get; set; }
        public virtual ICollection<DndRacefavoredcharacterclass> DndRacefavoredcharacterclass { get; set; }
        public virtual ICollection<DndRacespeed> DndRacespeed { get; set; }
    }
}
