namespace Improving.YeOldeTdd.Model.Tests
{
    using System;

    using Improving.YeOldeTdd.Logic.Factories;
    using Improving.YeOldeTdd.Model.Entities;
    using Improving.YeOldeTdd.Model.Entities.Weapons;
    using Improving.YeOldeTdd.Model.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Rhino.Mocks;

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
        [ExpectedException(typeof(ArgumentNullException))]
        public void CombatantThrowsExceptionWhenEquippedWithNullWeapon()
        {
            this.combatant.EquipWeapon(null);
        }

//        [TestMethod]
//        [ExpectedException(typeof(InvalidOperationException))]
//        public void CombatantThrowsExceptionWithoutPowerGenerator()
//        {
//            this.combatant.PowerGenerator = null;
//            this.combatant.Attack(this.enemyCombatant);
//        }

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
            this.combatant.EquipWeapon(new CatapultStone());
            this.combatant.Attack(this.enemyCombatant);
            Assert.AreNotEqual(combatantStartHealth, this.enemyCombatant.Health);
            Assert.IsTrue(this.enemyCombatant.WasAttacked);
        }

        [TestMethod]
        public void TestCombatantAttacksWithWeapon()
        {
            // Arrange.
            int expectedDamage = 20;
            IWeapon weaponMock = MockRepository.GeneratePartialMock<Weapon>();
            weaponMock.Expect(x => x.CalculateDamage()).Return(expectedDamage);
            weaponMock.Replay();

            Army enemyArmy = new Army(null) { Health = 100 };
            int enemyArmyHealth = enemyArmy.Health;

            // Act.
            this.combatant.EquipWeapon(weaponMock);
            this.combatant.Attack(enemyArmy);

            // Assert.
            Assert.AreEqual(expectedDamage, enemyArmyHealth - enemyArmy.Health);
            weaponMock.VerifyAllExpectations();
        }

        [TestMethod]
        public void TestCombatantDealsNoDamageWithoutWeapon()
        {
            Army enemyArmy = new Army(null) { Health = 100 };
            int enemyArmyHealth = enemyArmy.Health;

            this.combatant.Attack(enemyArmy);

            Assert.AreEqual(enemyArmyHealth, enemyArmy.Health);
            Assert.IsFalse(enemyArmy.WasAttacked);
        }
    }
}
