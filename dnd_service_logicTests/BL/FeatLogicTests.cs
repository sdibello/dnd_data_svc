using System.Linq;
using System.Threading.Tasks;
using dnd_service_logic.BL;
using dnd_service_logicTests.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dnd_service_logicTests.BL
{
    [TestClass]
    public class FeatLogicTests
    {
        [TestMethod]
        public async Task GetFeat_byId_returnsMatch()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new FeatLogic(context);

            var result = await logic.GetFeatAsync("200");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Power Attack", result[0].Name);
        }

        [TestMethod]
        public async Task GetFeat_bySlug_returnsMatch()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new FeatLogic(context);

            var result = await logic.GetFeatAsync("great-cleave");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(202L, result[0].Id);
        }

        [TestMethod]
        public async Task GetFeat_byNameWithSpaces_returnsMatch()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new FeatLogic(context);

            var result = await logic.GetFeatAsync("Power Attack");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(200L, result[0].Id);
        }

        [TestMethod]
        public async Task GetFeat_blank_returnsEmptyList()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new FeatLogic(context);

            var result = await logic.GetFeatAsync(" ");

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public async Task GetFeatRequirements_unknownFeat_returnsNull()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new FeatLogic(context);

            var result = await logic.GetFeatRequirementsAsync("unknown-feat");

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task GetFeatRequirements_returnsRequiredAndRequiredBy()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new FeatLogic(context);

            var result = await logic.GetFeatRequirementsAsync("cleave");

            Assert.IsNotNull(result);
            Assert.AreEqual(201L, result.RootFeatid);
            Assert.AreEqual("Power Attack", result.requiredFeats.Single().name);
            Assert.AreEqual("Great Cleave", result.FeatsRequiredBy.Single().name);
        }

        [TestMethod]
        public async Task GetFeatRequirements_usesRelatedFeatIds_notJoinIds()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new FeatLogic(context);

            var result = await logic.GetFeatRequirementsAsync("power-attack");

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.requiredFeats.Count);
            Assert.AreEqual(1, result.FeatsRequiredBy.Count);
            Assert.AreEqual(201L, result.FeatsRequiredBy[0].id);
        }
    }
}
