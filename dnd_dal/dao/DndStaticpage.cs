using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndStaticpage
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public string BodyHtml { get; set; }
    }
}
