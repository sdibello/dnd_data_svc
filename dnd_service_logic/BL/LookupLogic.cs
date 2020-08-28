using System;
using System.Collections.Generic;
using System.Text;
using dnd_dal;
using dnd_dal.query.Lookup;
using System.Linq;
using System.Web;
using dnd_service_logic.dto;


namespace dnd_service_logic.BL
{
    public class LookupLogic : BaseLogic
    {
        public LookupLogic(dndContext databaseContext)
        {
            base.db = databaseContext;
        }

        public List<DndRulebook> getRuleBooks()
        {
            Console.WriteLine(string.Format("log - LookupQuery - getRuleBooks "));
            LookupQuery lq = new LookupQuery(this.db);
            List<DndRulebook> lookupResult = null;

            try
            {
                List<DndRulebook> data;
                // get the spell #refactor
                lookupResult = lq.Query_dndRuleBooks().ToList();

                if (lookupResult != null)
                {
                    Console.WriteLine(string.Format("log - getSchools - getSchools - results {0}", lookupResult.Count()));
                    return lookupResult;
                };
            }
            catch (Exception) {
                throw;
            }

            return null;
        }

        public List<DndRulebook> getRuleBooks(List<long> ids)
        {
            Console.WriteLine(string.Format("log - LookupQuery - getRuleBooks "));
            LookupQuery lq = new LookupQuery(this.db);
            List<DndRulebook> lookupResult = null;

            try
            {
                List<DndRulebook> data;
                // get the spell #refactor
                lookupResult = lq.Query_dndRuleBooks(ids).ToList();

                if (lookupResult != null)
                {
                    Console.WriteLine(string.Format("log - getSchools - getSchools - results {0}", lookupResult.Count()));
                    return lookupResult;
                };
            }
            catch (Exception)
            {
                throw;
            }

            return null;
        }


    }
}
