using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndMonster
    {
        public DndMonster()
        {
            DndMonsterSubtypes = new HashSet<DndMonsterSubtypes>();
            DndMonsterhasfeat = new HashSet<DndMonsterhasfeat>();
            DndMonsterhasskill = new HashSet<DndMonsterhasskill>();
            DndMonsterspeed = new HashSet<DndMonsterspeed>();
        }

        public long Id { get; set; }
        public long RulebookId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public long? Page { get; set; }
        public long? SizeId { get; set; }
        public long TypeId { get; set; }
        public string HitDice { get; set; }
        public long Initiative { get; set; }
        public string ArmorClass { get; set; }
        public long? TouchArmorClass { get; set; }
        public long? FlatFootedArmorClass { get; set; }
        public long BaseAttack { get; set; }
        public long Grapple { get; set; }
        public string Attack { get; set; }
        public string FullAttack { get; set; }
        public long Space { get; set; }
        public long Reach { get; set; }
        public string SpecialAttacks { get; set; }
        public string SpecialQualities { get; set; }
        public long FortSave { get; set; }
        public string FortSaveExtra { get; set; }
        public long ReflexSave { get; set; }
        public string ReflexSaveExtra { get; set; }
        public long WillSave { get; set; }
        public string WillSaveExtra { get; set; }
        public long Str { get; set; }
        public long Dex { get; set; }
        public long? Con { get; set; }
        public long Int { get; set; }
        public long Wis { get; set; }
        public long Cha { get; set; }
        public string Environment { get; set; }
        public string Organization { get; set; }
        public long ChallengeRating { get; set; }
        public string Treasure { get; set; }
        public string Alignment { get; set; }
        public string Advancement { get; set; }
        public long? LevelAdjustment { get; set; }
        public string Description { get; set; }
        public string DescriptionHtml { get; set; }
        public string Combat { get; set; }
        public string CombatHtml { get; set; }

        public virtual DndRulebook Rulebook { get; set; }
        public virtual DndRacesize Size { get; set; }
        public virtual DndMonstertype Type { get; set; }
        public virtual ICollection<DndMonsterSubtypes> DndMonsterSubtypes { get; set; }
        public virtual ICollection<DndMonsterhasfeat> DndMonsterhasfeat { get; set; }
        public virtual ICollection<DndMonsterhasskill> DndMonsterhasskill { get; set; }
        public virtual ICollection<DndMonsterspeed> DndMonsterspeed { get; set; }
    }
}
