using System;
using System.Collections.Generic;
using System.Linq;
using dnd_dal.dto;

namespace dnd_dal.query.Lookup
{
    public class LookupQuery
    {

        public List<DndRulebook> Query_dndRuleBooks(List<long> ids)
        {
            var dndContext = new dndContext();

            var query =
                    from rulebook in dndContext.DndRulebook
                    where ids.Contains(rulebook.Id)
                    select rulebook;

            return query.ToList();
        }

        public List<DndRulebook> Query_dndRuleBooks()
        {
            var dndContext = new dndContext();

            var query =
                    from rulebook in dndContext.DndRulebook
                    select rulebook;

            return query.ToList();
        }

    }
}
