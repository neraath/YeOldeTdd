namespace Improving.YeOldeTdd.Logic.Tests
{
    using Improving.YeOldeTdd.Logic.Factories;
    using Improving.YeOldeTdd.Model;
    using Improving.YeOldeTdd.Model.Entities;
    using Improving.YeOldeTdd.Model.Factories;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class WarLogicTests
    {
        private Army armyA;

        private Army armyB;

        private WarLogic warLogic;

        [TestInitialize]
        public void InitializeTests()
        {
            var powerGenerator = new PowerGenerator();
            var weaponFactory = new WeaponFactory();
            var combatantFactory = new CombatantFactory(powerGenerator, weaponFactory);
            this.armyA = new Army(powerGenerator, combatantFactory) { Health = 100 };
            this.armyB = new Army(powerGenerator, combatantFactory) { Health = 100 };
            this.warLogic = new WarLogic();
        }

        [TestMethod]
        public void TestVictorDeclaredAfterGoingToWar()
        {
            IBattlefieldEntity victor = null;
            this.warLogic.OnWarEnding += (sender, warEndingArgs) => { victor = warEndingArgs.Victor; };
            this.warLogic.GoToWar(this.armyA, this.armyB);
            
            Assert.IsNotNull(victor, "Victor was not declared.");
        }
    }
}
