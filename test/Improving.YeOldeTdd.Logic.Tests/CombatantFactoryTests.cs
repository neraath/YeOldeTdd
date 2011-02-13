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

        private IEquipmentFactory equipmentFactory;

        private CombatantFactory combatantFactory;

        private IWeapon stubWeapon;

        [TestInitialize]
        public void InitializeTests()
        {
            this.powerGenerator = MockRepository.GenerateStub<IPowerGenerator>();
            this.equipmentFactory = MockRepository.GenerateStub<IEquipmentFactory>();
            this.combatantFactory = new CombatantFactory(this.powerGenerator, this.equipmentFactory);
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
            // Setup our stub.
            this.stubWeapon = MockRepository.GenerateStub<IWeapon>();
            this.equipmentFactory.Stub(x => x.EquipCombatant(null)).IgnoreArguments().Do(
                new EquipCombatant(this.StubEquipCombatant));
            this.equipmentFactory.Replay();
            this.stubWeapon.Expect(x => x.CalculateDamage()).Return(10);
            this.stubWeapon.Expect(x => x.CalculateDamage()).Return(10);

            // Get our combatants.
            string knightName = "My Knight";
            var knight = combatantFactory.CreateCombatant<Knight>(knightName);
            string randomCombatantName = "My Random Combatant";
            var randomCombatant = combatantFactory.CreateRandomCombatant(randomCombatantName);

            int catapultHealth = randomCombatant.Health;
            int knightHealth = knight.Health;

            randomCombatant.Attack(knight);
            knight.Attack(randomCombatant);

            this.equipmentFactory.VerifyAllExpectations();
            this.stubWeapon.VerifyAllExpectations();
            Assert.AreNotEqual(catapultHealth, randomCombatant.Health);
            Assert.AreNotEqual(knightHealth, knight.Health);
        }

        #region CombatantsCreatedThruFactoryCanAttack

        private delegate void EquipCombatant(ICombatant combatant);

        private void StubEquipCombatant(ICombatant combatant)
        {
            combatant.EquipWeapon(this.stubWeapon);
        }

        #endregion
    }
}
