using Microsoft.VisualStudio.TestTools.UnitTesting;
using dnd_service_logic.BL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace dnd_service_logic.BL.Tests
{
    [TestClass()]
    public class SpellLogicTests
    {
        [TestMethod()]
        public void GetSpellTest_byID()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpells("45");
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetSpellTest_byIDfail()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpells("232345");
            Assert.IsTrue(result.Count == 0);
        }


        [TestMethod()]
        public void GetSpellTest_byName()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpells("Cometfall");
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetSpellTest_byNamefail()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpells("Cometfaller");
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod()]
        public void GetSpellTest_byNameWithSpaceCAPS()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpells("magic MISSILE");
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetSpellTest_byNameWithSpace()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpells("magic missile");
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void GetSpellTest_bySlug()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpells("magic_missile");
            Assert.IsNotNull(result);
        }

    }
}