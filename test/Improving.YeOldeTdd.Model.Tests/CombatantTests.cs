namespace Improving.YeOldeTdd.Model.Tests
{
    using System;

    using Improving.YeOldeTdd.Logic.Factories;
    using Improving.YeOldeTdd.Model.Entities;
    using Improving.YeOldeTdd.Model.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CombatantTests
    {
        private Combatant combatant;

        private ICombatant enemyCombatant;

        [TestInitialize]
        public void InitializeTests()
        {
            var powerGenerator = new PowerGenerator();
            this.combatant = new Catapult() { Health = 100, PowerGenerator = powerGenerator };
            this.enemyCombatant = new Catapult() { Health = 100, PowerGenerator = powerGenerator };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CombatantThrowsExceptionWithoutPowerGenerator()
        {
            this.combatant.PowerGenerator = null;
            this.combatant.Attack(this.enemyCombatant);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CombatantThrowsExceptionWithoutTarget()
        {
            this.combatant.Attack(null);
        }

        [TestMethod]
        public void CombatantAttacksOtherCombatants()
        {
            int combatantStartHealth = this.enemyCombatant.Health;
            this.combatant.Attack(this.enemyCombatant);
            Assert.AreNotEqual(combatantStartHealth, this.enemyCombatant.Health);
        }
    }
}
