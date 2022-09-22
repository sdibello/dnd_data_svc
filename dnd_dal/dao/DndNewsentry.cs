using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndNewsentry
    {
        public long Id { get; set; }
        public byte[] Published { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string BodyHtml { get; set; }
        public long Enabled { get; set; }
    }
}
