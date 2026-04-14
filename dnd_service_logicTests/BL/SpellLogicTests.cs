using System.Linq;
using System.Threading.Tasks;
using dnd_service_logic.BL;
using dnd_service_logicTests.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dnd_service_logicTests.BL
{
    [TestClass]
    public class SpellLogicTests
    {
        [TestMethod]
        public async Task GetSpells_byId_returnsMatch()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new SpellLogic(context);

            var result = await logic.GetSpellsAsync("100");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Magic Missile", result[0].Name);
        }

        [TestMethod]
        public async Task GetSpells_bySlug_returnsMatch()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new SpellLogic(context);

            var result = await logic.GetSpellsAsync("magic-missile");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(100L, result[0].Id);
        }

        [TestMethod]
        public async Task GetSpells_byNameWithSpaces_returnsMatch()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new SpellLogic(context);

            var result = await logic.GetSpellsAsync("magic missile");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("magic-missile", result[0].Slug);
        }

        [TestMethod]
        public async Task GetSpells_blank_returnsEmptyList()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new SpellLogic(context);

            var result = await logic.GetSpellsAsync("   ");

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public async Task GetSpells_urlDecodedName_returnsMatch()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new SpellLogic(context);

            var result = await logic.GetSpellsAsync("Magic%20Missile");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(100L, result[0].Id);
        }

        [TestMethod]
        public async Task GetSpellsByClassAndLevel_valid_returnsResults()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new SpellLogic(context);

            var result = await logic.GetSpellsByClassAndLevelAsync("wizard", "1");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Magic Missile", result[0].SpellName);
        }

        [TestMethod]
        public async Task GetSpellsByClassAndLevel_unknownClass_returnsEmptyList()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new SpellLogic(context);

            var result = await logic.GetSpellsByClassAndLevelAsync("sorcerer", "1");

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public async Task GetSpellsByClassAndLevel_invalidLevel_returnsEmptyList()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new SpellLogic(context);

            var result = await logic.GetSpellsByClassAndLevelAsync("wizard", "two");

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public async Task GetSchools_spellWithSubschool_returnsPrimaryAndSecondary()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new SpellLogic(context);

            var result = await logic.GetSchoolsAsync("summon-ally");

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Conjuration", result.Single(x => x.isPrimary).SchoolName);
            Assert.AreEqual("Calling", result.Single(x => !x.isPrimary).SchoolName);
        }

        [TestMethod]
        public async Task GetSchools_unknownSpell_returnsEmptyList()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new SpellLogic(context);

            var result = await logic.GetSchoolsAsync("unknown-spell");

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public async Task GetClass_validSpell_returnsClasses()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new SpellLogic(context);

            var result = await logic.GetClassAsync("magic-missile");

            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEquivalent(new[] { "Wizard", "Warmage Adept" }, result.Select(x => x.ClassName).ToArray());
        }

        [TestMethod]
        public async Task GetClass_unknown_returnsEmptyList()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new SpellLogic(context);

            var result = await logic.GetClassAsync("asdfasdf");

            Assert.AreEqual(0, result.Count);
        }
    }
}
