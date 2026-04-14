using System;
using System.Linq;
using dnd_dal.dao;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace dnd_service_logicTests.TestSupport
{
    internal sealed class TestDbFactory : IDisposable
    {
        private readonly SqliteConnection _connection;

        public TestDbFactory()
        {
            _connection = new SqliteConnection("Data Source=:memory:");
            _connection.Open();

            using var context = CreateContext();
            context.Database.EnsureCreated();
            Seed(context);
        }

        public dndContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<dndContext>()
                .UseSqlite(_connection)
                .Options;

            return new dndContext(options);
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        private static void Seed(dndContext context)
        {
            if (context.DndRulebook.Any())
            {
                return;
            }

            context.DndDndedition.Add(new DndDndedition
            {
                Id = 1,
                Name = "D&D 3.5",
                System = "D20",
                Slug = "dnd-35",
                Core = 1
            });

            context.DndRulebook.Add(new DndRulebook
            {
                Id = 1,
                DndEditionId = 1,
                Name = "Player's Handbook",
                Abbr = "PHB",
                Description = "Core rules",
                Year = "2003",
                OfficialUrl = "https://example.test/phb",
                Slug = "players-handbook",
                Image = "phb.png",
                Published = Array.Empty<byte>()
            });

            context.DndSpellschool.AddRange(
                new DndSpellschool { Id = 1, Name = "Evocation", Slug = "evocation" },
                new DndSpellschool { Id = 2, Name = "Conjuration", Slug = "conjuration" });

            context.DndSpellsubschool.Add(
                new DndSpellsubschool { Id = 1, Name = "Calling", Slug = "calling" });

            context.DndCharacterclass.AddRange(
                new DndCharacterclass
                {
                    Id = 1,
                    Name = "Wizard",
                    Slug = "wizard",
                    Prestige = 0,
                    ShortDescription = "Arcane caster",
                    ShortDescriptionHtml = "<p>Arcane caster</p>"
                },
                new DndCharacterclass
                {
                    Id = 2,
                    Name = "Warmage Adept",
                    Slug = "warmage-adept",
                    Prestige = 0,
                    ShortDescription = "Hybrid caster",
                    ShortDescriptionHtml = "<p>Hybrid caster</p>"
                });

            context.DndSpell.AddRange(
                new DndSpell
                {
                    Id = 100,
                    Added = Array.Empty<byte>(),
                    RulebookId = 1,
                    Name = "Magic Missile",
                    SchoolId = 1,
                    VerbalComponent = 1,
                    SomaticComponent = 1,
                    MaterialComponent = 0,
                    ArcaneFocusComponent = 0,
                    DivineFocusComponent = 0,
                    XpComponent = 0,
                    CastingTime = "1 action",
                    Range = "Medium",
                    Target = "One or more creatures",
                    Effect = string.Empty,
                    Area = string.Empty,
                    Duration = "Instantaneous",
                    SavingThrow = "None",
                    SpellResistance = "Yes",
                    Description = "Force bolts strike targets.",
                    Slug = "magic-missile",
                    MetaBreathComponent = 0,
                    TrueNameComponent = 0,
                    ExtraComponents = string.Empty,
                    DescriptionHtml = "<p>Force bolts strike targets.</p>",
                    CorruptComponent = 0,
                    Verified = 1,
                    VerifiedTime = Array.Empty<byte>()
                },
                new DndSpell
                {
                    Id = 101,
                    Added = Array.Empty<byte>(),
                    RulebookId = 1,
                    Name = "Summon Ally",
                    SchoolId = 2,
                    SubSchoolId = 1,
                    VerbalComponent = 1,
                    SomaticComponent = 1,
                    MaterialComponent = 0,
                    ArcaneFocusComponent = 0,
                    DivineFocusComponent = 0,
                    XpComponent = 0,
                    CastingTime = "1 round",
                    Range = "Close",
                    Target = string.Empty,
                    Effect = "One summoned creature",
                    Area = string.Empty,
                    Duration = "1 round/level",
                    SavingThrow = "None",
                    SpellResistance = "No",
                    Description = "Summons an extraplanar ally.",
                    Slug = "summon-ally",
                    MetaBreathComponent = 0,
                    TrueNameComponent = 0,
                    ExtraComponents = string.Empty,
                    DescriptionHtml = "<p>Summons an extraplanar ally.</p>",
                    CorruptComponent = 0,
                    Verified = 1,
                    VerifiedTime = Array.Empty<byte>()
                });

            context.DndSpellclasslevel.AddRange(
                new DndSpellclasslevel { Id = 1, CharacterClassId = 1, SpellId = 100, Level = 1, Extra = string.Empty },
                new DndSpellclasslevel { Id = 2, CharacterClassId = 1, SpellId = 101, Level = 3, Extra = string.Empty },
                new DndSpellclasslevel { Id = 3, CharacterClassId = 2, SpellId = 100, Level = 2, Extra = string.Empty });

            context.DndFeat.AddRange(
                new DndFeat
                {
                    Id = 200,
                    RulebookId = 1,
                    Name = "Power Attack",
                    Description = "Trade accuracy for damage.",
                    Benefit = "Extra damage",
                    Special = string.Empty,
                    Normal = string.Empty,
                    Slug = "power-attack",
                    DescriptionHtml = "<p>Trade accuracy for damage.</p>",
                    BenefitHtml = "<p>Extra damage</p>",
                    SpecialHtml = string.Empty,
                    NormalHtml = string.Empty
                },
                new DndFeat
                {
                    Id = 201,
                    RulebookId = 1,
                    Name = "Cleave",
                    Description = "Gain an extra attack after a kill.",
                    Benefit = "Extra attack",
                    Special = string.Empty,
                    Normal = string.Empty,
                    Slug = "cleave",
                    DescriptionHtml = "<p>Gain an extra attack after a kill.</p>",
                    BenefitHtml = "<p>Extra attack</p>",
                    SpecialHtml = string.Empty,
                    NormalHtml = string.Empty
                },
                new DndFeat
                {
                    Id = 202,
                    RulebookId = 1,
                    Name = "Great Cleave",
                    Description = "Continue cleaving.",
                    Benefit = "More extra attacks",
                    Special = string.Empty,
                    Normal = string.Empty,
                    Slug = "great-cleave",
                    DescriptionHtml = "<p>Continue cleaving.</p>",
                    BenefitHtml = "<p>More extra attacks</p>",
                    SpecialHtml = string.Empty,
                    NormalHtml = string.Empty
                });

            context.DndFeatrequiresfeat.AddRange(
                new DndFeatrequiresfeat { Id = 900, SourceFeatId = 201, RequiredFeatId = 200, AdditionalText = string.Empty },
                new DndFeatrequiresfeat { Id = 901, SourceFeatId = 202, RequiredFeatId = 201, AdditionalText = string.Empty });

            context.SaveChanges();
        }
    }
}
