 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_graphql_svc.dto
{
    public class Spell
    {
        public long Id { get; set; }
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
        public List<KeyValuePair<long, String>> search { get; set; }
    }
}
