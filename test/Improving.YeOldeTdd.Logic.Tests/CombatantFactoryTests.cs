namespace Improving.YeOldeTdd.Logic.Tests
{
    using Improving.YeOldeTdd.Logic.Factories;
    using Improving.YeOldeTdd.Model.Entities;
    using Improving.YeOldeTdd.Model.Factories;
    using Improving.YeOldeTdd.Model.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Rhino.Mocks;

    [TestClass]
    public class CombatantFactoryTests
    {
        private IPowerGenerator powerGenerator;
        private CombatantFactory combatantFactory;

        [TestInitialize]
        public void InitializeTests()
        {
            this.powerGenerator = MockRepository.GenerateStub<IPowerGenerator>();
            this.combatantFactory = new CombatantFactory(this.powerGenerator);
        }

        [TestMethod]
        public void CombatantFactoryCreatesCatapults()
        {
            string name = "My Catapult";
            var catapult = combatantFactory.CreateCombatant<Catapult>(name);
            Assert.IsInstanceOfType(catapult, typeof(Catapult), "Returned type is not a Catapult");
            Assert.AreEqual(name, catapult.Name);
        }

        [TestMethod]
        public void CombatantFactoryCreatesKnights()
        {
            string name = "My Knight";
            var knight = combatantFactory.CreateCombatant<Knight>(name);
            Assert.IsInstanceOfType(knight, typeof(Knight), "Returned type is not a Knight");
            Assert.AreEqual(name, knight.Name);
        }

        [TestMethod]
        public void CombatantFactoryCreatesRandomCombatants()
        {
            string combatantName = "Test Combatant";
            var combatant = combatantFactory.CreateRandomCombatant(combatantName);

            Assert.IsNotNull(combatant);
            Assert.AreEqual(combatantName, combatant.Name);
        }

        [TestMethod]
        public void CombatantsCreatedThruFactoryCanAttack()
        {
            string knightName = "My Knight";
            var knight = combatantFactory.CreateCombatant<Knight>(knightName);
            string randomCombatantName = "My Random Combatant";
            var randomCombatant = combatantFactory.CreateRandomCombatant(randomCombatantName);

            int catapultHealth = randomCombatant.Health;
            int knightHealth = knight.Health;

            // Setup our stub.
            this.powerGenerator.Stub(x => x.GeneratePower()).Return(1);

            randomCombatant.Attack(knight);
            knight.Attack(randomCombatant);

            Assert.AreNotEqual(catapultHealth, randomCombatant.Health);
            Assert.AreNotEqual(knightHealth, knight.Health);
            this.powerGenerator.VerifyAllExpectations();
        }
    }
}
