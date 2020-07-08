using System;
using System.Collections.Generic;
using System.Text;

namespace dnd_dal.dto
{
    public  class SpellSchoolSubSchool
    {
        public long SpellId { get; set; }
        public long? SchoolId { get; set; }
        public string SchoolName { get; set; }
        public long? SubSchoolId { get; set; }
        public string SubSchoolName { get; set; }
    }
}
