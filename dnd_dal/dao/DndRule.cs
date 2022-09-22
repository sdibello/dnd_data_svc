using System;
using System.Collections.Generic;

namespace dnd_dal.dao
{
    public partial class DndRule
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public string BodyHtml { get; set; }
        public long RulebookId { get; set; }
        public long? PageFrom { get; set; }
        public long? PageTo { get; set; }

        public virtual DndRulebook Rulebook { get; set; }
    }
}
