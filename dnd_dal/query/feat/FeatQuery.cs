using System;
using System.Collections.Generic;
using System.Text;
using dnd_dal;
using System.Linq;
using dnd_dal.dto;
using System.ComponentModel.DataAnnotations;

namespace dnd_dal.query.feat
{
    public class FeatQuery
    {

        public List<DndFeat> Query_dndFeatByID(long featId)
        {
            dndContext db = new dndContext();

            var query =
                    from feat in db.DndFeat
                    where feat.Id == featId
                    select feat;

            return query.ToList();

        }

        public List<DndFeat> Query_dndFeatByName(string featName)
        {
            dndContext db = new dndContext();

            var query =
                    from feat in db.DndFeat
                    where feat.Name.ToLower() == featName.ToLower()
                    select feat;

            return query.ToList();

        }

        public List<DndFeat> Query_dndFeatBySlug(string featSlug)
        {
            dndContext db = new dndContext();

            var query =
                    from feat in db.DndFeat
                    where feat.Slug.ToLower() == featSlug.ToLower()
                    select feat;

            return query.ToList();

        }

        public List<DndFeatrequiresfeat> Query_dndFeatRequiredFeat(long featId)
        {
            dndContext db = new dndContext();

            var query =
                    from req in db.DndFeatrequiresfeat
                    where req.RequiredFeatId == featId
                    select req;

            return query.ToList();
        }

        public List<DndFeatrequiresfeat> Query_dndFeatRequiredBy(long featId)
        {
            dndContext db = new dndContext();

            var query =
                    from req in db.DndFeatrequiresfeat
                    where req.SourceFeatId == featId
                    select req;

            return query.ToList();
        }

    }
}
