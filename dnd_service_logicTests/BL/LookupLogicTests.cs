using System.Threading.Tasks;
using dnd_service_logic.BL;
using dnd_service_logicTests.TestSupport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dnd_service_logicTests.BL
{
    [TestClass]
    public class LookupLogicTests
    {
        [TestMethod]
        public async Task GetRuleBooks_returnsAllRulebooks()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new LookupLogic(context);

            var result = await logic.GetRuleBooksAsync();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Player's Handbook", result[0].Name);
        }

        [TestMethod]
        public async Task GetRuleBooks_byIds_filtersResults()
        {
            using var factory = new TestDbFactory();
            using var context = factory.CreateContext();
            var logic = new LookupLogic(context);

            var result = await logic.GetRuleBooksAsync(new System.Collections.Generic.List<long> { 1 });

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1L, result[0].Id);
        }
    }
}
