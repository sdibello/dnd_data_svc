using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_graphql_svc.Models
{
    public class Spell
    {
        public int id { get; set; }
        public DateTime added { get; set; }
        public int rulebook_id { get; set; }
        public int? page { get; set; }
        public int name { get; set; }
        public int school_id { get; set; }
        public int sub_school_id { get; set; }
        public bool verbal_component { get; set; }
        public bool somatic_component { get; set; }
        public bool material_component { get; set; }
        public bool arcane_focus_component { get; set; }
        public bool divine_focus_component { get; set; }
        public bool xp_component { get; set; }
        public string casting_time { get; set; }
        public string range { get; set; }
        public string target { get; set; }
        public string effect { get; set; }
        public string area { get; set; }
        public string duration { get; set; }
        public string saving_throw { get; set; }
        public string spell_resistance { get; set; }
        public string description { get; set; }
        public string slug { get; set; }
        public int mate_breath_component { get; set; }
        public int true_name_component{ get; set; }
        public string extra_components { get; set; }
        public string description_html { get; set; }
        public int component_currupt { get; set; }
        public int companent_level { get; set; }
        public int verified { get; set; }
        public int verified_author_id { get; set; }
        public int verified_time { get; set; }
    }
}
