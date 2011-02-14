namespace Improving.YeOldeTdd.Logic.Tests.Behaviors
{
    using Improving.YeOldeTdd.Logic.Factories;
    using Improving.YeOldeTdd.Model.Entities;
    using Improving.YeOldeTdd.Model.Factories;
    using Improving.YeOldeTdd.Model.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DeclaringWar
    {
        #region Private Members

        private WarLogic logic;

        private IPowerGenerator powerGenerator;

        private ICombatantFactory combatantFactory;

        private Army armyA;

        private Army armyB;

        #endregion

        [TestInitialize]
        public void InitializeTests()
        {
            this.logic = new WarLogic();
            this.powerGenerator = new PowerGenerator();
            this.combatantFactory = new CombatantFactory(this.powerGenerator);
            this.armyA = new Army(this.powerGenerator, this.combatantFactory);
            this.armyB = new Army(this.powerGenerator, this.combatantFactory);
        }

        [TestMethod]
        public void ShouldResultInAVictor()
        {
            Army victor = null;
            this.logic.OnWarEnding += (sender, args) => { victor = args.Victor; Assert.IsNotNull(victor); };
            this.logic.GoToWar(this.armyA, this.armyB);
        }
    }
}
