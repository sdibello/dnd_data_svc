using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dnd_dal.dao;
using Microsoft.EntityFrameworkCore;

namespace dnd_service_logic.BL
{
    public class LookupLogic : ILookupLogic
    {
        private readonly dndContext _db;

        public LookupLogic(dndContext db)
        {
            _db = db;
        }

        public Task<List<DndRulebook>> GetRuleBooksAsync()
        {
            return _db.DndRulebook.AsNoTracking().ToListAsync();
        }

        public Task<List<DndRulebook>> GetRuleBooksAsync(List<long> ids)
        {
            return _db.DndRulebook
                .AsNoTracking()
                .Where(x => ids.Contains(x.Id))
                .ToListAsync();
        }
    }
}
