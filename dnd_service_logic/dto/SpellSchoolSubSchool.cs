using System;
using System.Collections.Generic;
using System.Text;

namespace dnd_service_logic.dto
{
    public  class SpellSchoolSubSchool
    {
        public long SpellId { get; set; }
        public String Spellname { get; set; }
        public long? SchoolId { get; set; }
        public string SchoolName { get; set; }
        public Boolean isPrimary { get; set; }
    }
}
