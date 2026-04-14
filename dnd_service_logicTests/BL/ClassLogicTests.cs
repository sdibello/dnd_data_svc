using System.Linq;
using System.Threading.Tasks;
using dnd_service_logic.BL;
using dnd_service_logicTests.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dnd_service_logicTests.BL
{
    [TestClass]
    public class ClassLogicTests
    {
        [TestMethod]
        public async Task GetDbClass_byId_returnsMatch()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new ClassLogic(context);

            var result = await logic.GetDbClassAsync("1");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Wizard", result[0].Name);
        }

        [TestMethod]
        public async Task GetDbClass_bySlug_returnsMatch()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new ClassLogic(context);

            var result = await logic.GetDbClassAsync("warmage-adept");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(2L, result[0].Id);
        }

        [TestMethod]
        public async Task GetDbClass_byNameWithSpaces_returnsMatch()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new ClassLogic(context);

            var result = await logic.GetDbClassAsync("Warmage Adept");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("warmage-adept", result[0].Slug);
        }

        [TestMethod]
        public async Task GetDbClass_blank_returnsEmptyList()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new ClassLogic(context);

            var result = await logic.GetDbClassAsync(" ");

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public async Task GetClassSpells_returnsOrderedSpells()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new ClassLogic(context);

            var result = await logic.GetClassSpellsAsync("wizard");

            Assert.AreEqual(2, result.Count);
            CollectionAssert.AreEqual(new[] { "Magic Missile", "Summon Ally" }, result.Select(x => x.SpellName).ToArray());
            CollectionAssert.AreEqual(new long[] { 1, 3 }, result.Select(x => x.Level).ToArray());
        }

        [TestMethod]
        public async Task GetClassSpells_unknownClass_returnsEmptyList()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new ClassLogic(context);

            var result = await logic.GetClassSpellsAsync("unknown-class");

            Assert.AreEqual(0, result.Count);
        }
    }
}
