using Microsoft.VisualStudio.TestTools.UnitTesting;
using dnd_service_logic.BL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace dnd_service_logicTests.BL
{
    [TestClass()]
    public class SpellLogicTests
    {
        #region Spell Get Tests

        [TestMethod()]
        public void GetSpellTest_byID()
        {
            SpellLogic sl = new();
            var result = sl.getSpells("45");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void GetSpellTest_byIDfail()
        {
            SpellLogic sl = new();
            var result = sl.getSpells("232345");
            Assert.IsTrue(result.Count == 0);
        }


        [TestMethod()]
        public void GetSpellTest_byName()
        {
            SpellLogic sl = new();
            var result = sl.getSpells("Cometfall");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void GetSpellTest_byNamefail()
        {
            SpellLogic sl = new();
            var result = sl.getSpells("Cometfaller");
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod()]
        public void GetSpellTest_byNameWithSpaceCAPS()
        {
            SpellLogic sl = new();
            var result = sl.getSpells("magic MISSILE");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void GetSpellTest_byNameWithSpace()
        {
            SpellLogic sl = new();
            var result = sl.getSpells("magic missile");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void GetSpellTest_byNameWithSpaceFail()
        {
            SpellLogic sl = new();
            var result = sl.getSpells("magic missiled");
            Assert.IsTrue(result.Count == 0);
        }


        [TestMethod()]
        public void GetSpellTest_bySlug()
        {
            SpellLogic sl = new();
            var result = sl.getSpells("magic-missile");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void GetSpellTest_bySlugFail()
        {
            SpellLogic sl = new();
            var result = sl.getSpells("magic_missileed");
            Assert.IsTrue(result.Count == 0);
        }

        #endregion

        #region Get Spells By Class and Level

        [TestMethod()]
        public void GetSpellsByClassAndLevelTest()
        {
            SpellLogic sl = new();
            var result = sl.getSpellsByClassAndLevel("WIZARD", "2");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void GetSpellsByClassAndLevelTestTwo()
        {
            SpellLogic sl = new();
            var result = sl.getSpellsByClassAndLevel("wizard", "2");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void GetSpellsByClassAndLevelTest_fail()
        {
            SpellLogic sl = new();
            var result = sl.getSpellsByClassAndLevel("Wizard", "12");
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod()]
        public void GetSpellsByClassAndLevelTest_failTwo()
        {
            SpellLogic sl = new();
            var result = sl.getSpellsByClassAndLevel("Dog", "2");
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod()]
        public void GetSpellsByClassAndLevelTest_reversed()
        {
            SpellLogic sl = new();
            var result = sl.getSpellsByClassAndLevel("2", "wizard");
            Assert.IsNull(result);
        }

        [TestMethod()]
        public void GetSpellsByClassAndLevelTest_spelledOut()
        {
            SpellLogic sl = new();
            var result = sl.getSpellsByClassAndLevel("wizard", "two");
            Assert.IsNull(result);
        }


        #endregion

        #region get schools

        [TestMethod()]
        public void getSchoolsTest_BySlug()
        {
            SpellLogic sl = new();
            var result = sl.getSchools("magic-missile");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void getSchoolsTest_fail()
        {
            SpellLogic sl = new();
            var result = sl.getSchools("magic-missiled");
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod()]
        public void getSchoolsTest_byNumber()
        {
            SpellLogic sl = new();
            var result = sl.getSchools("123");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void getSchoolsTest_bySubSchool()
        {
            SpellLogic sl = new();
            var result = sl.getSchools("Restoration");
            Assert.IsTrue(result.Count == 2);
        }




        [TestMethod()]
        public void getSchoolsTest_byPlainName()
        {
            SpellLogic sl = new();
            var result = sl.getSchools("fireball");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void getSchoolsTest_byPlainNameFail()
        {
            SpellLogic sl = new();
            var result = sl.getSchools("fireballsd");
            Assert.IsTrue(result.Count == 0);
        }


        #endregion

        #region Get Class

        [TestMethod()]
        public void getClassTest()
        {
            SpellLogic sl = new();
            var result = sl.getClass("fireball");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void getClassTestbyID()
        {
            SpellLogic sl = new();
            var result = sl.getClass("123");
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod()]
        public void getClassTest_fail()
        {
            SpellLogic sl = new();
            var result = sl.getClass("asdfasdf");
            Assert.IsNull(result);
        }

        #endregion

    }
}