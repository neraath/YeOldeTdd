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

        private Army enemyArmy;

        /// <summary>
        /// Sets up our unit test suite prior to each unit test. 
        /// </summary>
        [TestInitialize]
        public void TestSetup()
        {
            this.army = new Army();
            this.enemyArmy = new Army();
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
            this.army.Attack(this.enemyArmy);
            Assert.IsTrue(this.enemyArmy.WasAttacked);
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
            int enemyHealth = this.enemyArmy.Health;
            this.army.Attack(this.enemyArmy);
            Assert.AreNotEqual(enemyHealth, this.enemyArmy.Health, "Health of enemy remains the same. Attack did not occur.");
        }

        [TestMethod]
        public void ArmyCanKillOpponent()
        {
            int enemyHealth = this.enemyArmy.Health;
            for (int i = 0; i < enemyHealth; i++)
            {
                this.army.Attack(this.enemyArmy);
            }
            
            Assert.IsFalse(this.enemyArmy.IsAlive);
        }

        /// <summary>
        /// This is a brittle test. Why?
        /// </summary>
        [TestMethod]
        public void ArmyCanDoDamageWithoutKilling()
        {
            int enemyHealth = this.enemyArmy.Health;
            for (int i = 0; i < enemyHealth / 2; i++)
            {
                this.army.Attack(this.enemyArmy);
            }

            Assert.IsTrue(this.enemyArmy.IsAlive);
        }

        [TestMethod]
        public void ArmyAsStringIsUseful()
        {
            this.army.Name = "Celtics";
            
            // This is brittle. Why?
            Assert.AreSame("Celtics", this.army.ToString(), "The army's name is not present.");

            // This is better. 
            Assert.AreNotEqual("Improving.YeOldeTdd.Model.Entities.Army", this.army.ToString(), "The army has a bad string representation.");

            // This really reveals what you are looking for.
            Assert.IsTrue(this.army.ToString().Contains(this.army.Name));
        }
    }
}
