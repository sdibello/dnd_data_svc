using System.Collections.Generic;
using System.Threading.Tasks;
using dnd_dal.dao;
using dnd_graphql_svc.Controllers;
using dnd_service_logic.BL;
using dnd_service_logic.dto;
using dnd_service_logicTests.TestSupport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dnd_service_logicTests.Controllers
{
    [TestClass]
    public class ControllerTests
    {
        [TestMethod]
        public async Task SpellsController_GetSpell_returnsNotFoundForEmptyResults()
        {
            using var factory = LoggerFactory.Create(_ => { });
            using var dbFactory = new TestDbFactory();
            using var context = dbFactory.CreateContext();
            var controller = new SpellsController(context, new SpellLogicStub(), factory.CreateLogger<SpellsController>());

            var result = await controller.GetSpell("missing");

            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task SpellsController_SearchByClassLevel_returnsBadRequestForInvalidLevel()
        {
            using var factory = LoggerFactory.Create(_ => { });
            using var dbFactory = new TestDbFactory();
            using var context = dbFactory.CreateContext();
            var controller = new SpellsController(context, new SpellLogicStub(), factory.CreateLogger<SpellsController>());

            var result = await controller.SearchSpellByClassAndLevel("wizard", "two");

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task SpellsController_UpdateIndex_returnsIndexedCount()
        {
            using var factory = LoggerFactory.Create(_ => { });
            using var dbFactory = new TestDbFactory();
            using var context = dbFactory.CreateContext();
            var controller = new SpellsController(context, new SpellLogicStub(), factory.CreateLogger<SpellsController>());

            var result = await controller.UpdateIndex();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task FeatController_GetFeat_returnsNotFoundForEmptyResults()
        {
            using var factory = LoggerFactory.Create(_ => { });
            var controller = new FeatController(new FeatLogicStub(), factory.CreateLogger<FeatController>());

            var result = await controller.GetFeat("missing");

            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task FeatController_GetFeatTree_returnsNotFoundForMissingFeat()
        {
            using var factory = LoggerFactory.Create(_ => { });
            var controller = new FeatController(new FeatLogicStub(), factory.CreateLogger<FeatController>());

            var result = await controller.GetFeatTree("missing");

            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task ClassController_GetClass_returnsNotFoundForEmptyResults()
        {
            using var factory = LoggerFactory.Create(_ => { });
            var controller = new ClassController(new ClassLogicStub(), factory.CreateLogger<ClassController>());

            var result = await controller.GetClass("missing");

            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task LookupController_GetRulebooks_returnsBadRequestForInvalidIds()
        {
            using var factory = LoggerFactory.Create(_ => { });
            var controller = new LookupController(new LookupLogicStub(), factory.CreateLogger<LookupController>());

            var result = await controller.GetRulebooks("1,abc");

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }

        private sealed class SpellLogicStub : ISpellLogic
        {
            public Task<List<SpellCL>> GetClassAsync(string spell) => Task.FromResult(new List<SpellCL>());
            public Task<List<DndSpell>> GetDbSpellAsync(string spell) => Task.FromResult(new List<DndSpell>());
            public Task<List<SpellSchoolSubSchool>> GetSchoolsAsync(string spell) => Task.FromResult(new List<SpellSchoolSubSchool>());
            public Task<List<Spell>> GetSpellsAsync(string spell) => Task.FromResult(new List<Spell>());
            public Task<List<SpellCL>> GetSpellsByClassAndLevelAsync(string casterClass, string casterLevel) => Task.FromResult(new List<SpellCL>());
        }

        private sealed class FeatLogicStub : IFeatLogic
        {
            public Task<List<DndFeat>> GetFeatAsync(string id) => Task.FromResult(new List<DndFeat>());
            public Task<FeatTree?> GetFeatRequirementsAsync(string id) => Task.FromResult<FeatTree?>(null);
        }

        private sealed class ClassLogicStub : IClassLogic
        {
            public Task<List<DndCharacterclass>> GetDbClassAsync(string classParam) => Task.FromResult(new List<DndCharacterclass>());
            public Task<List<ClassSpell>> GetClassSpellsAsync(string classParam) => Task.FromResult(new List<ClassSpell>());
        }

        private sealed class LookupLogicStub : ILookupLogic
        {
            public Task<List<DndRulebook>> GetRuleBooksAsync() => Task.FromResult(new List<DndRulebook>());
            public Task<List<DndRulebook>> GetRuleBooksAsync(List<long> ids) => Task.FromResult(new List<DndRulebook>());
        }
    }
}
