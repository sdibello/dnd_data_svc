using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_graphql_svc.dto
{
    public class ClassSpell
    {
        public string SpellName { get; set; }
        public long SpellId { get; set; }
        public long ClassId { get; set; }
        public string ClassName { get; set; }
        public long Level { get; set; }
    }
}
