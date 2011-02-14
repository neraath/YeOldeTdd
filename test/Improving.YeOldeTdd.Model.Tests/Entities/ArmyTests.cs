namespace Improving.YeOldeTdd.Model.Tests.Entities
{
    using System;
    using System.Linq;

    using Improving.YeOldeTdd.Logic.Factories;
    using Improving.YeOldeTdd.Model.Entities;
    using Improving.YeOldeTdd.Model.Factories;
    using Improving.YeOldeTdd.Model.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Rhino.Mocks;

    [TestClass]
    public class ArmyTests
    {
        private Army army;

        private Army enemyArmy;

        private IPowerGenerator powerGenerator;

        private ICombatantFactory combatantFactory;

        /// <summary>
        /// Refactored twice.
        /// </summary>
        [TestInitialize]
        public void InitializeTests()
        {
            powerGenerator = new PowerGenerator();
            combatantFactory = new CombatantFactory(powerGenerator);
            army = new Army(powerGenerator, combatantFactory);
            enemyArmy = new Army(powerGenerator, combatantFactory);
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

        /// <summary>
        /// Refactored twice.
        /// </summary>
        [TestMethod]
        public void ArmyInflictsDamageToEnemy()
        {
            // Arrange.
            int enemyStartingHealth = enemyArmy.Health;
            int powerOfAttack = 10;
            IPowerGenerator generator = (IPowerGenerator)MockRepository.GenerateStub<IPowerGenerator>();
            var combatantFactory = new CombatantFactory(generator);
            generator.Expect(x => x.GeneratePower()).Return(powerOfAttack);
            this.army = new Army(generator, combatantFactory);
            // army.Power = powerOfAttack; // Replaced above.
            
            // Act.
            army.Attack(enemyArmy);

            // Assert.
            Assert.AreEqual(powerOfAttack, enemyStartingHealth - enemyArmy.Health);
        }

        /// <summary>
        /// Refactored twice.
        /// </summary>
        [TestMethod]
        public void RepeatedAttacksKillsOpponent()
        {
            // Arrange.
            int powerOfAttack = 10;
            IPowerGenerator generator = MockRepository.GenerateStub<IPowerGenerator>();
            generator.Expect(x => x.GeneratePower()).Return(powerOfAttack);
            Combatant combatant = new Combatant(generator);
            ICombatantFactory factory = MockRepository.GenerateStub<ICombatantFactory>();
            factory.Expect(x => x.CreateRandomCombatant()).Return(combatant);
            this.army = new Army(generator, factory);
            //army.Power = powerOfAttack;

            // Act.
            while (enemyArmy.Health > 0)
            {
                army.Attack(enemyArmy);
            }

            Assert.IsFalse(enemyArmy.IsAlive);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ArmyAttackThrowsExceptionIfNoPowerRandomizer()
        {
            this.army = new Army();
            this.army.Attack(this.enemyArmy);
        }

        /// <summary>
        /// Warning: Quite brittle.
        /// </summary>
//        [TestMethod]
//        public void ArmyPowerOfAttackIsRandom()
//        {
//            var powerGenerator = new PowerGenerator();
//            this.army = new Army(powerGenerator);
//
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
        /// <remarks>Refactored</remarks>
        [TestMethod]
        public void ArmyPowerOfAttackControlled()
        {
            int[] lossOfHealth = new int[3];

            var powerGeneratorStub = MockRepository.GenerateStub<IPowerGenerator>();
            var combatantFactory = new CombatantFactory(powerGeneratorStub);
            this.army = new Army(powerGeneratorStub, combatantFactory);
            powerGeneratorStub.Stub(x => x.GeneratePower()).Return(1);
            powerGeneratorStub.Replay();

            int enemyHealth = this.enemyArmy.Health;
            this.army.Attack(this.enemyArmy);
            lossOfHealth[0] = enemyHealth - this.enemyArmy.Health;

            powerGeneratorStub.BackToRecord();
            powerGeneratorStub.Stub(x => x.GeneratePower()).Return(10);
            powerGeneratorStub.Replay();

            enemyHealth = this.enemyArmy.Health;
            this.army.Attack(this.enemyArmy);
            lossOfHealth[1] = enemyHealth - this.enemyArmy.Health;

            powerGeneratorStub.BackToRecord();
            powerGeneratorStub.Stub(x => x.GeneratePower()).Return(5);
            powerGeneratorStub.Replay();

            enemyHealth = this.enemyArmy.Health;
            this.army.Attack(this.enemyArmy);
            lossOfHealth[2] = enemyHealth - this.enemyArmy.Health;

            var numberOfDistinctValues = lossOfHealth.Distinct();
            Assert.AreEqual(3, numberOfDistinctValues.Count(), "Power of attack is not random.");
            powerGeneratorStub.VerifyAllExpectations();
        }

        [TestMethod]
        public void ArmyAttacksWithCombatants()
        {
            IPowerGenerator generatorStub = MockRepository.GenerateStub<IPowerGenerator>();
            ICombatantFactory factoryStub = MockRepository.GenerateStub<ICombatantFactory>();
            Combatant mockCombatant1 = MockRepository.GeneratePartialMock<Combatant>(generatorStub);
            Army enemyArmy = new Army(generatorStub) { Health = 100 };

            // Setup our mock and stub expectations.
            factoryStub.Stub(x => x.CreateRandomCombatant()).IgnoreArguments().Return(mockCombatant1);

            mockCombatant1.Expect(x => x.Attack(enemyArmy)).Do(
                new CombatantAttack(this.StubCombatantAttacksOpponent));
            mockCombatant1.Replay();

            // Initialize our army and attack.
            Army myArmy = new Army(generatorStub, factoryStub);
            myArmy.Attack(enemyArmy);

            factoryStub.VerifyAllExpectations();
            mockCombatant1.VerifyAllExpectations();
        }

        private delegate void CombatantAttack(IBattlefieldEntity enemy);

        private void StubCombatantAttacksOpponent(IBattlefieldEntity enemy)
        {
            enemy.Health--;
        }
    }
}
