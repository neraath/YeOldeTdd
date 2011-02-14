namespace Improving.YeOldeTdd.Model.Tests.Behaviors
{
    using Improving.YeOldeTdd.Logic.Factories;
    using Improving.YeOldeTdd.Model.Entities;
    using Improving.YeOldeTdd.Model.Factories;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArmyAttacking
    {
        #region Private Members

        private CombatantFactory combatantFactory;

        private PowerGenerator powerGenerator;

        private Army army;

        private Army enemyArmy;

        #endregion

        [TestInitialize]
        public void InitializeSuite()
        {
            this.powerGenerator = new PowerGenerator();
            this.combatantFactory = new CombatantFactory(this.powerGenerator);
            this.army = new Army(this.powerGenerator, this.combatantFactory);
            this.enemyArmy = new Army(this.powerGenerator, this.combatantFactory);
        }

        [TestMethod]
        public void ShouldDiminishHealthOfOpponent()
        {
            int beginningHealth = this.enemyArmy.Health;
            this.army.Attack(this.enemyArmy);
            Assert.AreNotEqual(beginningHealth, this.enemyArmy.Health);
        }

        [TestMethod]
        public void ShouldIndicateThatEnemyWasAttacked()
        {
            this.army.Attack(this.enemyArmy);
            Assert.IsTrue(this.enemyArmy.WasAttacked);
        }

        [TestMethod]
        public void ShouldKillOpponentWithEnoughAttacks()
        {
            // Minimum attack power is 1. Thus, iterate maximum of 100 times.
            for (int i = 0; i < 100; i++)
            {
                this.army.Attack(this.enemyArmy);
                if (!this.enemyArmy.IsAlive) break;
            }

            Assert.IsFalse(this.enemyArmy.IsAlive);
        }
    }
}
