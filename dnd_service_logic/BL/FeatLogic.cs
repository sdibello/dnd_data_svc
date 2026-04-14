using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dnd_dal.dao;
using dnd_service_logic.dto;
using Microsoft.EntityFrameworkCore;

namespace dnd_service_logic.BL
{
    public class FeatLogic : IFeatLogic
    {
        private readonly dndContext _db;

        public FeatLogic(dndContext db)
        {
            _db = db;
        }

        public async Task<List<DndFeat>> GetFeatAsync(string id)
        {
            var normalized = System.Uri.UnescapeDataString(id ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(normalized))
            {
                return new List<DndFeat>();
            }

            IQueryable<DndFeat> query = _db.DndFeat.AsNoTracking();

            if (long.TryParse(normalized, out var longId))
            {
                return await query.Where(x => x.Id == longId).ToListAsync();
            }

            if (normalized.Contains(' '))
            {
                return await query.Where(x => x.Name.ToLower() == normalized.ToLower()).ToListAsync();
            }

            return await query.Where(x => x.Slug.ToLower() == normalized.ToLower()).ToListAsync();
        }

        public async Task<FeatTree?> GetFeatRequirementsAsync(string id)
        {
            var feat = await GetFeatAsync(id);
            var rootFeat = feat.FirstOrDefault();
            if (rootFeat == null)
            {
                return null;
            }

            var relationships = await _db.DndFeatrequiresfeat
                .AsNoTracking()
                .Where(x => x.RequiredFeatId == rootFeat.Id || x.SourceFeatId == rootFeat.Id)
                .ToListAsync();

            var requiredIds = relationships
                .Where(x => x.SourceFeatId == rootFeat.Id)
                .Select(x => x.RequiredFeatId)
                .Distinct()
                .ToList();

            var requiredByIds = relationships
                .Where(x => x.RequiredFeatId == rootFeat.Id)
                .Select(x => x.SourceFeatId)
                .Distinct()
                .ToList();

            var relatedIds = requiredIds.Concat(requiredByIds).Distinct().ToList();
            var relatedFeats = await _db.DndFeat
                .AsNoTracking()
                .Where(x => relatedIds.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id, x => x.Name);

            return new FeatTree
            {
                RootFeatid = rootFeat.Id,
                RootFeatName = rootFeat.Name,
                requiredFeats = requiredIds
                    .Where(relatedFeats.ContainsKey)
                    .Select(x => new BasicFeat { id = x, name = relatedFeats[x] })
                    .ToList(),
                FeatsRequiredBy = requiredByIds
                    .Where(relatedFeats.ContainsKey)
                    .Select(x => new BasicFeat { id = x, name = relatedFeats[x] })
                    .ToList()
            };
        }
    }
}
