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
        #region Spell Get Tests

        [TestMethod()]
        public void GetSpellTest_byID()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpells("45");
            Assert.IsTrue(result.Count > 0);
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
            Assert.IsTrue(result.Count > 0);
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
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void GetSpellTest_byNameWithSpace()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpells("magic missile");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void GetSpellTest_byNameWithSpaceFail()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpells("magic missiled");
            Assert.IsTrue(result.Count == 0);
        }


        [TestMethod()]
        public void GetSpellTest_bySlug()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpells("magic-missile");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void GetSpellTest_bySlugFail()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpells("magic_missileed");
            Assert.IsTrue(result.Count == 0);
        }

        #endregion

        #region Get Spells By Class and Level

        [TestMethod()]
        public void GetSpellsByClassAndLevelTest()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpellsByClassAndLevel("WIZARD", "2");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void GetSpellsByClassAndLevelTestTwo()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpellsByClassAndLevel("wizard", "2");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void GetSpellsByClassAndLevelTest_fail()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpellsByClassAndLevel("Wizard", "12");
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod()]
        public void GetSpellsByClassAndLevelTest_failTwo()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpellsByClassAndLevel("Dog", "2");
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod()]
        public void GetSpellsByClassAndLevelTest_reversed()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpellsByClassAndLevel("2", "wizard");
            Assert.IsNull(result);
        }

        [TestMethod()]
        public void GetSpellsByClassAndLevelTest_spelledOut()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSpellsByClassAndLevel("wizard", "two");
            Assert.IsNull(result);
        }


        #endregion

        #region get schools

        [TestMethod()]
        public void getSchoolsTest_BySlug()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSchools("magic-missile");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void getSchoolsTest_fail()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSchools("magic-missiled");
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod()]
        public void getSchoolsTest_byNumber()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSchools("123");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void getSchoolsTest_bySubSchool()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSchools("Restoration");
            Assert.IsTrue(result.Count == 2);
        }


        

        [TestMethod()]
        public void getSchoolsTest_byPlainName()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSchools("fireball");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void getSchoolsTest_byPlainNameFail()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getSchools("fireballsd");
            Assert.IsTrue(result.Count == 0);
        }


        #endregion

        #region Get Class

        [TestMethod()]
        public void getClassTest()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getClass("fireball");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void getClassTestbyID()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getClass("123");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void getClassTest_fail()
        {
            dnd_service_logic.BL.SpellLogic sl = new();
            var result = sl.getClass("asdfasdf");
            Assert.IsNull(result);
        }

        #endregion

    }
}