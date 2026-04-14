using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dnd_dal.dao;
using dnd_service_logic.dto;
using Microsoft.EntityFrameworkCore;

namespace dnd_service_logic.BL
{
    public class SpellLogic : ISpellLogic
    {
        private readonly dndContext _db;

        public SpellLogic(dndContext db)
        {
            _db = db;
        }

        public async Task<List<SpellCL>> GetSpellsByClassAndLevelAsync(string casterClass, string casterLevel)
        {
            if (!long.TryParse(casterLevel, out var level))
            {
                return new List<SpellCL>();
            }

            return await (
                from cc in _db.DndCharacterclass.AsNoTracking()
                join scl in _db.DndSpellclasslevel.AsNoTracking() on cc.Id equals scl.CharacterClassId
                join s in _db.DndSpell.AsNoTracking() on scl.SpellId equals s.Id
                where cc.Slug.ToLower() == casterClass.ToLower()
                where scl.Level == level
                orderby s.Name
                select new SpellCL
                {
                    ClassId = cc.Id,
                    ClassName = cc.Name,
                    Level = scl.Level,
                    SpellId = s.Id,
                    SpellName = s.Name
                }).ToListAsync();
        }

        public async Task<List<SpellSchoolSubSchool>> GetSchoolsAsync(string spell)
        {
            var spells = await GetDbSpellAsync(spell);
            if (spells.Count == 0)
            {
                return new List<SpellSchoolSubSchool>();
            }

            var schoolIds = spells
                .Select(s => s.SchoolId)
                .Distinct()
                .ToList();

            var subSchoolIds = spells
                .Where(s => s.SubSchoolId.HasValue)
                .Select(s => s.SubSchoolId!.Value)
                .Distinct()
                .ToList();

            var schoolLookup = await _db.DndSpellschool
                .AsNoTracking()
                .Where(x => schoolIds.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id, x => x.Name);

            var subSchoolLookup = await _db.DndSpellsubschool
                .AsNoTracking()
                .Where(x => subSchoolIds.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id, x => x.Name);

            var result = new List<SpellSchoolSubSchool>();
            foreach (var item in spells)
            {
                if (schoolLookup.TryGetValue(item.SchoolId, out var primaryName))
                {
                    result.Add(new SpellSchoolSubSchool
                    {
                        SpellId = item.Id,
                        Spellname = item.Name,
                        isPrimary = true,
                        SchoolId = item.SchoolId,
                        SchoolName = primaryName
                    });
                }

                if (item.SubSchoolId.HasValue && subSchoolLookup.TryGetValue(item.SubSchoolId.Value, out var secondaryName))
                {
                    result.Add(new SpellSchoolSubSchool
                    {
                        SpellId = item.Id,
                        Spellname = item.Name,
                        isPrimary = false,
                        SchoolId = item.SubSchoolId,
                        SchoolName = secondaryName
                    });
                }
            }

            return result;
        }

        public async Task<List<DndSpell>> GetDbSpellAsync(string spell)
        {
            var normalized = Uri.UnescapeDataString(spell ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(normalized))
            {
                return new List<DndSpell>();
            }

            IQueryable<DndSpell> query = _db.DndSpell.AsNoTracking();

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

        public async Task<List<SpellCL>> GetClassAsync(string spell)
        {
            var spells = await GetDbSpellAsync(spell);
            if (spells.Count == 0)
            {
                return new List<SpellCL>();
            }

            var spellIds = spells.Select(x => x.Id).ToList();
            var classLevels = await _db.DndSpellclasslevel
                .AsNoTracking()
                .Where(x => spellIds.Contains(x.SpellId))
                .ToListAsync();

            if (classLevels.Count == 0)
            {
                return new List<SpellCL>();
            }

            var classIds = classLevels.Select(x => x.CharacterClassId).Distinct().ToList();
            var classes = await _db.DndCharacterclass
                .AsNoTracking()
                .Where(x => classIds.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id, x => x.Name);

            var spellNames = spells.ToDictionary(x => x.Id, x => x.Name);

            return classLevels
                .Where(x => classes.ContainsKey(x.CharacterClassId) && spellNames.ContainsKey(x.SpellId))
                .Select(x => new SpellCL
                {
                    SpellId = x.SpellId,
                    SpellName = spellNames[x.SpellId],
                    ClassId = x.CharacterClassId,
                    ClassName = classes[x.CharacterClassId],
                    Level = x.Level
                })
                .ToList();
        }

        public async Task<List<Spell>> GetSpellsAsync(string spell)
        {
            var spells = await GetDbSpellAsync(spell);

            return spells.Select(s => new Spell
            {
                Id = s.Id,
                Description = s.Description,
                Name = s.Name,
                CastingTime = s.CastingTime,
                Range = s.Range,
                SavingThrow = s.SavingThrow,
                SpellResistance = s.SpellResistance,
                Duration = s.Duration,
                Target = s.Target,
                Effect = s.Effect,
                Area = s.Area,
                Slug = s.Slug,
                Page = s.Page,
                SubSchoolId = s.SubSchoolId,
                SchoolId = s.SchoolId,
                ArcaneFocusComponent = s.ArcaneFocusComponent,
                DivineFocusComponent = s.DivineFocusComponent,
                MaterialComponent = s.MaterialComponent,
                SomaticComponent = s.SomaticComponent,
                VerbalComponent = s.VerbalComponent,
                XpComponent = s.XpComponent,
                RulebookId = s.RulebookId
            }).ToList();
        }
    }
}
