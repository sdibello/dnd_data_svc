using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_dal.dto
{
    public class SpellClassLevel
    {
        public long SpellId { get; set; }
        public string SpellName { get; set; }
        public long ClassId { get; set; }
        public string ClassName { get; set; }
        public long LevelForClass { get; set; }
    }
}
