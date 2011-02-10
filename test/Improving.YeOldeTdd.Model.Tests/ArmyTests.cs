namespace Improving.YeOldeTdd.Model.Tests
{
    using System;

    using Improving.YeOldeTdd.Model.Entities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ArmyTests
    {
        private Army army;

        /// <summary>
        /// Sets up our unit test suite prior to each unit test. 
        /// </summary>
        [TestInitialize]
        public void TestSetup()
        {
            this.army = new Army();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestArmyCannotAttackEmptyTarget()
        {
            Army enemyArmy = null;
            this.army.Attack(enemyArmy);
        }

        [TestMethod]
        public void TestArmyCanAttack()
        {
            var enemyArmy = new Army();
            this.army.Attack(enemyArmy);
            Assert.IsTrue(enemyArmy.WasAttacked);
        }

        [TestMethod]
        public void InitialArmyHealthMustNotBeZero()
        {
            Assert.AreNotEqual(0, this.army.Health, "Army health is starting at 0.");
        }
        
        [TestMethod]
        public void InitialArmyPowerMustNotBeZero()
        {
            Assert.AreNotEqual(0, this.army.Power, "Initial power is 0.");
        }

        [TestMethod]
        public void ArmyDoesDamageToTarget()
        {
            var enemyArmy = new Army();
            int enemyHealth = enemyArmy.Health;
            this.army.Attack(enemyArmy);
            Assert.AreNotEqual(enemyHealth, enemyArmy.Health, "Health of enemy remains the same. Attack did not occur.");
        }
    }
}
