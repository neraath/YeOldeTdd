namespace Improving.YeOldeTdd.Model.Tests
{
    using System;
    using System.Linq;

    using Improving.YeOldeTdd.Logic.Factories;
    using Improving.YeOldeTdd.Model.Entities;
    using Improving.YeOldeTdd.Model.Factories;
    using Improving.YeOldeTdd.Model.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Rhino.Mocks;

    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ArmyTests
    {
        private Army army;

        private Army enemyArmy;

        private IWeapon stubWeapon;

        /// <summary>
        /// Sets up our unit test suite prior to each unit test. 
        /// </summary>
        [TestInitialize]
        public void TestSetup()
        {
            var powerGenerator = new PowerGenerator();
            var weaponFactory = new WeaponFactory();
            var combatantFactory = new CombatantFactory(powerGenerator, weaponFactory);
            this.army = new Army(powerGenerator, combatantFactory) { Health = 100 };
            this.enemyArmy = new Army(powerGenerator, combatantFactory) { Health = 100 };
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
//        [TestMethod]
//        public void ArmyCanDoDamageWithoutKilling()
//        {
//            int enemyHealth = this.enemyArmy.Health;
//            for (int i = 0; i < enemyHealth / 2; i++)
//            {
//                this.army.Attack(this.enemyArmy);
//            }
//
//            Assert.IsTrue(this.enemyArmy.IsAlive);
//        }

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

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ArmyAttackThrowsExceptionIfNoCombatantFactory()
        {
            this.army = new Army(null, null);
            this.army.Attack(this.enemyArmy);
        }

//        [TestMethod]
//        [ExpectedException(typeof(InvalidOperationException))]
//        public void ArmyAttackThrowsExceptionIfNoPowerRandomizer()
//        {
//            this.army.PowerGenerator = null;
//            this.army.Attack(this.enemyArmy);
//        }

        /// <summary>
        /// Warning: Quite brittle.
        /// </summary>
//        [TestMethod]
//        public void ArmyPowerOfAttackIsRandom()
//        {
//            int[] lossOfHealth = new int[10];
//
//            for (int i = 0; i < 10; i++)
//            {
//                int enemyHealth = this.enemyArmy.Health;
//                this.army.Attack(this.enemyArmy);
//                lossOfHealth[i] = enemyHealth - this.enemyArmy.Health;
//            }
//
            // Assert that loss of health varies across the array.
//            var numberOfDistinctValues = lossOfHealth.Distinct();
//            Assert.AreNotEqual(1, numberOfDistinctValues.Count(), "Power of attack doesn't seem random.");
//        }

        /// <summary>
        /// Much more reliable than the one above. 
        /// </summary>
        [TestMethod]
        public void ArmyPowerOfAttackControlled()
        {
            this.stubWeapon = MockRepository.GenerateStub<IWeapon>();
            var weaponFactoryStub = MockRepository.GenerateStub<IEquipmentFactory>();
            var powerGeneratorStub = MockRepository.GenerateStub<IPowerGenerator>();
            var combatantFactory = new CombatantFactory(powerGeneratorStub, weaponFactoryStub);
            this.army = new Army(powerGeneratorStub, combatantFactory);

            weaponFactoryStub.Expect(x => x.EquipCombatant(null)).IgnoreArguments().Do(
                new EquipCombatant(this.StubEquipCombatant));
            weaponFactoryStub.Replay();

            int expectedDamage = 10;
            this.stubWeapon.Expect(x => x.CalculateDamage()).Return(expectedDamage);

            int enemyHealth = this.enemyArmy.Health;
            this.army.Attack(this.enemyArmy);
            weaponFactoryStub.VerifyAllExpectations();
            this.stubWeapon.VerifyAllExpectations();
            Assert.AreEqual(expectedDamage, enemyHealth - this.enemyArmy.Health);
        }

        [TestMethod]
        public void ArmyAttacksWithCombatants()
        {
            IPowerGenerator generatorStub = MockRepository.GenerateStub<IPowerGenerator>();
            ICombatantFactory factoryStub = MockRepository.GenerateStub<ICombatantFactory>();
            Combatant mockCombatant1 = MockRepository.GeneratePartialMock<Combatant>();
            Army enemyArmy = new Army(generatorStub) { Health = 100 };

            // Setup our mock and stub expectations.
            factoryStub.Stub(x => x.CreateRandomCombatant("Test Combatant")).IgnoreArguments().Return(mockCombatant1);
            //factoryStub.Stub(x => x.CreateRandomCombatant("Fake Combatant")).IgnoreArguments().Return(mockCombatant2);

            mockCombatant1.Expect(x => x.Attack(enemyArmy)).Do(
                new CombatantAttack(this.StubCombatantAttacksOpponent));
            mockCombatant1.Replay();

            // Initialize our army and attack.
            Army myArmy = new Army(generatorStub, factoryStub);
            myArmy.Attack(enemyArmy);

            factoryStub.VerifyAllExpectations();
            mockCombatant1.VerifyAllExpectations();
        }

        #region ArmyPowerOfAttackControlled

        private delegate void EquipCombatant(ICombatant combatant);

        private void StubEquipCombatant(ICombatant combatant)
        {
            combatant.EquipWeapon(this.stubWeapon);
        }

        #endregion

        #region ArmyAttacksWithCombatants Delegate

        private delegate void CombatantAttack(IBattlefieldEntity enemy);

        private void StubCombatantAttacksOpponent(IBattlefieldEntity enemy)
        {
            enemy.Health--;
        }

        #endregion
    }
}
