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
        public void getSpellTest()
        {
            //SpellLogic spelllogic = new SpellLogic();
            dnd_service_logic.BL.SpellLogic sl = new SpellLogic();
            var result = sl.getSpells("45");
            Assert.IsNotNull(result);
        }
    }
}