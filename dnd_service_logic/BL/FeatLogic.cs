using dnd_dal.query.feat;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Linq;
using dnd_service_logic.dto;
using Microsoft.EntityFrameworkCore;
using dnd_dal.dao;

namespace dnd_service_logic.BL
{
    public class FeatLogic
    {
        public  List<DndFeat> GetFeat(string id)
        {
            long longId;
            FeatQuery fq = new FeatQuery();
            List<DndFeat> featdb = new List<DndFeat>();

            if (long.TryParse(id, out longId) == true) 
            {
                featdb = fq.Query_dndFeatByID(longId);
            }
            else
            {
                if (id.IndexOf(' ') > 0) {
                    featdb = fq.Query_dndFeatByName(id);
                }
                else
                {
                    featdb = fq.Query_dndFeatBySlug(id);
                }
            }

            if (featdb != null)
            {
                Console.WriteLine(string.Format("log - get feat - ({0}) ", id));
            };
            return featdb;
        }

        public FeatTree GetFeatRequirements(string id)
        {
            FeatQuery fq = new FeatQuery();
            
            List<DndFeat> feat = GetFeat(id);
            List<DndFeatrequiresfeat> queryRequired = fq.Query_dndFeatRequiredFeat(feat.First().Id);
            List<DndFeatrequiresfeat> queryRequiredBy = fq.Query_dndFeatRequiredBy(feat.First().Id);
            FeatTree data = new FeatTree();

            data.RootFeatid = feat.First().Id;
            data.RootFeatName = feat.First().Name;

            foreach (var item in queryRequired)
            {
                var thisfeat = GetFeat(item.Id.ToString());
                foreach (var each in thisfeat)
                {
                    var bf = new BasicFeat
                    {
                        id = each.Id,
                        name = each.Name
                    };
                    data.requiredFeats.Add(bf);
                }
            }

            foreach (var item in queryRequiredBy)
            {
                var thisfeat = GetFeat(item.Id.ToString());
                foreach (var each in thisfeat)
                {
                    var bf = new BasicFeat
                    {
                        id = each.Id,
                        name = each.Name
                    };
                    data.FeatsRequiredBy.Add(bf);

                }
            }

            return data;
        }
    }
}
