namespace Improving.YeOldeTdd.Logic.Tests
{
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
            this.armyA = new Army();
            this.armyB = new Army();
            this.warLogic = new WarLogic();
        }

        [TestMethod]
        public void TestVictorDeclaredAfterGoingToWar()
        {
            Army victor = null;
            this.warLogic.OnWarEnding += (sender, warEndingArgs) => { victor = warEndingArgs.Victor; };
            this.warLogic.GoToWar(this.armyA, this.armyB);
            
            Assert.IsNotNull(victor, "Victor was not declared.");
        }
    }
}
