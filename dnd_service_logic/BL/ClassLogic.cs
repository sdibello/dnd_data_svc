using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dnd_dal.dao;
using dnd_service_logic.dto;
using Microsoft.EntityFrameworkCore;

namespace dnd_service_logic.BL
{
    public class ClassLogic : IClassLogic
    {
        private readonly dndContext _db;

        public ClassLogic(dndContext db)
        {
            _db = db;
        }

        public async Task<List<DndCharacterclass>> GetDbClassAsync(string classParam)
        {
            var normalized = Uri.UnescapeDataString(classParam ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(normalized))
            {
                return new List<DndCharacterclass>();
            }

            IQueryable<DndCharacterclass> query = _db.DndCharacterclass.AsNoTracking();

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

        public async Task<List<ClassSpell>> GetClassSpellsAsync(string classParam)
        {
            var classes = await GetDbClassAsync(classParam);
            if (classes.Count == 0)
            {
                return new List<ClassSpell>();
            }

            var classIds = classes.Select(x => x.Id).ToList();
            var spellLevels = await _db.DndSpellclasslevel
                .AsNoTracking()
                .Where(x => classIds.Contains(x.CharacterClassId))
                .ToListAsync();

            if (spellLevels.Count == 0)
            {
                return new List<ClassSpell>();
            }

            var spellIds = spellLevels.Select(x => x.SpellId).Distinct().ToList();
            var spellNames = await _db.DndSpell
                .AsNoTracking()
                .Where(x => spellIds.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id, x => x.Name);

            var classNames = classes.ToDictionary(x => x.Id, x => x.Name);

            return spellLevels
                .Where(x => spellNames.ContainsKey(x.SpellId) && classNames.ContainsKey(x.CharacterClassId))
                .Select(x => new ClassSpell
                {
                    ClassId = x.CharacterClassId,
                    ClassName = classNames[x.CharacterClassId],
                    Level = x.Level,
                    SpellId = x.SpellId,
                    SpellName = spellNames[x.SpellId]
                })
                .OrderBy(x => x.Level)
                .ThenBy(x => x.SpellName)
                .ToList();
        }
    }
}
