using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_graphql_svc.dto
{
    public class FeatTree
    {
        public long RootFeatid { get; set; }
        public string RootFeatName { get; set; }
        public List<BasicFeat> requiredFeats { get; set; }
        public List<BasicFeat> FeatsRequiredBy { get; set; }
    }

    public class BasicFeat
    {
        public long id { get; set; }
        public string name { get; set; }
    }
}
