﻿namespace Improving.YeOldeTdd.Logic.Tests
{
    using Improving.YeOldeTdd.Logic.Factories;
    using Improving.YeOldeTdd.Model.Entities;
    using Improving.YeOldeTdd.Model.Factories;
    using Improving.YeOldeTdd.Model.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class WarLogicTests
    {
        #region Private Members

        private Army armyA;

        private Army armyB;

        private WarLogic warLogic;

        private IPowerGenerator powerGenerator;

        private ICombatantFactory combatantFactory;

        #endregion

        [TestInitialize]
        public void InitializeTests()
        {
            this.powerGenerator = new PowerGenerator();
            this.combatantFactory = new CombatantFactory(this.powerGenerator);
            this.armyA = new Army(this.powerGenerator, this.combatantFactory);
            this.armyB = new Army(this.powerGenerator, this.combatantFactory);
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
