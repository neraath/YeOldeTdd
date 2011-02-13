namespace Improving.YeOldeTdd.Model.Tests.Entities
{
    using System;

    using Improving.YeOldeTdd.Model.Entities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ArmyTests
    {
        [TestMethod]
        public void TestArmyCanAttack()
        {
            // Arrange.
            Army army = new Army();
            Army enemyArmy = new Army();

            // Act.
            army.Attack(enemyArmy);

            // Assert.
            Assert.IsTrue(enemyArmy.WasAttacked);
        }

        [TestMethod]
        public void TestArmyThrowsExceptionWhenArmyIsNull()
        {
            // Arrange.
            Army army = new Army();
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
            Army army = new Army();
            army.Attack(null);
        }
    }
}
