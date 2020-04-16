using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_graphql_svc.Models
{
    public class Rulebook
    {
        public int id { get; set; }
        public int edition { get; set; }
        public string name { get; set; }
        public string abbr { get; set; }
        public string description { get; set; }
        public string year { get; set; }
        public string official_url { get; set; }
        public string slug { get; set; }
        public string image { get; set; }
    }
}
