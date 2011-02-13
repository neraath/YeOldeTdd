namespace Improving.YeOldeTdd.Model.Tests
{
    using System;

    using Improving.YeOldeTdd.Logic.Factories;
    using Improving.YeOldeTdd.Model.Entities;
    using Improving.YeOldeTdd.Model.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CatapultTests
    {
        private Catapult catapult;

        private ICombatant combatant;

        [TestInitialize]
        public void InitializeTests()
        {
            var powerGenerator = new PowerGenerator();
            this.catapult = new Catapult() { Health = 100, PowerGenerator = powerGenerator };
            this.combatant = new Catapult() { Health = 100, PowerGenerator = powerGenerator };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CatapultThrowsExceptionWithoutPowerGenerator()
        {
            this.catapult.PowerGenerator = null;
            this.catapult.Attack(this.combatant);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CatapultThrowsExceptionWithoutTarget()
        {
            this.catapult.Attack(null);
        }

        [TestMethod]
        public void CatapultAttacksOtherCombatants()
        {
            int combatantStartHealth = this.combatant.Health;
            this.catapult.Attack(this.combatant);
            Assert.AreNotEqual(combatantStartHealth, this.combatant.Health);
        }
    }
}
