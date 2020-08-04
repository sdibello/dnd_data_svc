using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_service_logic.dto
{
    public class SpellCL
    {
        public long SpellId { get; set; }
        public long ClassId { get; set; }
        public long Level { get; set; }
        public string ClassName { get; set; }
        public string SpellName { get; set; }
    }
}
