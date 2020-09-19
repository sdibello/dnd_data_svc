using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dnd_service_logic.dto
{
    public class FeatTree
    {
        public FeatTree()
        {
            this.requiredFeats = new List<BasicFeat>();
            this.FeatsRequiredBy = new List<BasicFeat>();
        }

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
