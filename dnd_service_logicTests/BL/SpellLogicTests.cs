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
        public void getSpellTest_byID()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpells("45");
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void getSpellTest_byIDfail()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpells("232345");
            Assert.IsTrue(result.Count == 0);
        }


        [TestMethod()]
        public void getSpellTest_byName()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpells("Cometfall");
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void getSpellTest_byNamefail()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpells("Cometfaller");
            Assert.IsTrue(result.Count == 0);
        }


    }
}