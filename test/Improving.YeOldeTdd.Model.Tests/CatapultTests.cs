namespace Improving.YeOldeTdd.Model.Tests
{
    using Improving.YeOldeTdd.Logic.Factories;
    using Improving.YeOldeTdd.Model.Entities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CatapultTests
    {
        private Catapult catapult;

        private string name = "Brown-Red 1";

        [TestInitialize]
        public void InitializeTests()
        {
            this.catapult = new Catapult() { Name = this.name, Health = 100, PowerGenerator = new PowerGenerator() };
        }

        [TestMethod]
        public void TestCatapultToStringContainsUsefulInformation()
        {
            Assert.AreNotEqual("Improving.YeOldeTdd.Model.Entities.Catapult", this.catapult.ToString());
            Assert.IsTrue(this.catapult.ToString().Contains("Catapult"));
            Assert.IsTrue(this.catapult.ToString().Contains(this.name));
        }
    }
}
