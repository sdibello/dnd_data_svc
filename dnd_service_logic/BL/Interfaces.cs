using System.Collections.Generic;
using System.Threading.Tasks;
using dnd_dal.dao;
using dnd_service_logic.dto;

namespace dnd_service_logic.BL
{
    public interface ISpellLogic
    {
        Task<List<SpellCL>> GetSpellsByClassAndLevelAsync(string casterClass, string casterLevel);
        Task<List<SpellSchoolSubSchool>> GetSchoolsAsync(string spell);
        Task<List<DndSpell>> GetDbSpellAsync(string spell);
        Task<List<SpellCL>> GetClassAsync(string spell);
        Task<List<Spell>> GetSpellsAsync(string spell);
    }

    public interface IFeatLogic
    {
        Task<List<DndFeat>> GetFeatAsync(string id);
        Task<FeatTree?> GetFeatRequirementsAsync(string id);
    }

    public interface ILookupLogic
    {
        Task<List<DndRulebook>> GetRuleBooksAsync();
        Task<List<DndRulebook>> GetRuleBooksAsync(List<long> ids);
    }

    public interface IClassLogic
    {
        Task<List<DndCharacterclass>> GetDbClassAsync(string classParam);
        Task<List<ClassSpell>> GetClassSpellsAsync(string classParam);
    }
}
