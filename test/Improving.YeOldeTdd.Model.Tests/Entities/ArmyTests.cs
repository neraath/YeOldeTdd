namespace Improving.YeOldeTdd.Model.Tests.Entities
{
    using System;

    using Improving.YeOldeTdd.Model.Entities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArmyTests
    {
        private Army army;

        private Army enemyArmy;

        [TestInitialize]
        public void InitializeTests()
        {
            this.army = new Army();
            this.enemyArmy = new Army();
        }

        [TestMethod]
        public void TestArmyCanAttack()
        {
            // Act.
            army.Attack(enemyArmy);

            // Assert.
            Assert.IsTrue(enemyArmy.WasAttacked);
        }

        [TestMethod]
        public void TestArmyThrowsExceptionWhenArmyIsNull()
        {
            // Arrange.
            bool exceptionCaught = false;

            // Act.
            try
            {
                army.Attack(null);
            }
            catch (ArgumentNullException e)
            {
                exceptionCaught = true;
            }

            // Assert.
            Assert.IsTrue(exceptionCaught);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestArmyThrowsExceptionWhenArmyIsNullShort()
        {
            army.Attack(null);
        }

        [TestMethod]
        public void ArmyStartsWith100Health()
        {
            // Assert.
            Assert.AreEqual(100, this.army.Health);
        }

        [TestMethod]
        public void ArmyInflictsDamageToEnemy()
        {
            // Arrange.
            int enemyStartingHealth = enemyArmy.Health;
            int powerOfAttack = 10;
            army.Power = powerOfAttack;

            // Act.
            army.Attack(enemyArmy);

            // Assert
            Assert.AreEqual(powerOfAttack, enemyStartingHealth - enemyArmy.Health);
        }
    }
}
