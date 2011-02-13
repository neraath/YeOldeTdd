namespace Improving.YeOldeTdd.Logic.Tests
{
    using Improving.YeOldeTdd.Logic.Factories;
    using Improving.YeOldeTdd.Model;
    using Improving.YeOldeTdd.Model.Entities;

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
            this.armyA = new Army() { Health = 100, PowerGenerator = powerGenerator };
            this.armyB = new Army() { Health = 100, PowerGenerator = powerGenerator };
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
