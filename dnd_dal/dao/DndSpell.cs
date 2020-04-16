using System;
using System.Collections.Generic;

namespace dnd_dal
{
    public partial class DndSpell
    {
        public DndSpell()
        {
            DndItemRequiredSpells = new HashSet<DndItemRequiredSpells>();
            DndSpellDescriptors = new HashSet<DndSpellDescriptors>();
            DndSpellclasslevel = new HashSet<DndSpellclasslevel>();
            DndSpelldomainlevel = new HashSet<DndSpelldomainlevel>();
        }

        public long Id { get; set; }
        public byte[] Added { get; set; }
        public long RulebookId { get; set; }
        public long? Page { get; set; }
        public string Name { get; set; }
        public long SchoolId { get; set; }
        public long? SubSchoolId { get; set; }
        public long VerbalComponent { get; set; }
        public long SomaticComponent { get; set; }
        public long MaterialComponent { get; set; }
        public long ArcaneFocusComponent { get; set; }
        public long DivineFocusComponent { get; set; }
        public long XpComponent { get; set; }
        public string CastingTime { get; set; }
        public string Range { get; set; }
        public string Target { get; set; }
        public string Effect { get; set; }
        public string Area { get; set; }
        public string Duration { get; set; }
        public string SavingThrow { get; set; }
        public string SpellResistance { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public long MetaBreathComponent { get; set; }
        public long TrueNameComponent { get; set; }
        public string ExtraComponents { get; set; }
        public string DescriptionHtml { get; set; }
        public long CorruptComponent { get; set; }
        public long? CorruptLevel { get; set; }
        public long Verified { get; set; }
        public long? VerifiedAuthorId { get; set; }
        public byte[] VerifiedTime { get; set; }

        public virtual DndRulebook Rulebook { get; set; }
        public virtual DndSpellschool School { get; set; }
        public virtual DndSpellsubschool SubSchool { get; set; }
        public virtual ICollection<DndItemRequiredSpells> DndItemRequiredSpells { get; set; }
        public virtual ICollection<DndSpellDescriptors> DndSpellDescriptors { get; set; }
        public virtual ICollection<DndSpellclasslevel> DndSpellclasslevel { get; set; }
        public virtual ICollection<DndSpelldomainlevel> DndSpelldomainlevel { get; set; }
    }
}
