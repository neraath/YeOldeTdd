namespace Improving.YeOldeTdd.Model.Tests
{
    using Improving.YeOldeTdd.Logic.Factories;
    using Improving.YeOldeTdd.Model.Entities;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class KnightTests
    {
        private Knight knight;

        private string name = "Sir Galliant the Brave";

        [TestInitialize]
        public void InitializeTests()
        {
            this.knight = new Knight() { Name = this.name, Health = 100, PowerGenerator = new PowerGenerator() };
        }

        [TestMethod]
        public void TestKnightToStringPresentsUsefulInformation()
        {
            Assert.AreNotEqual("Improving.YeOldeTdd.Model.Entities.Knight", this.knight.ToString());
            Assert.IsTrue(this.knight.ToString().Contains(this.name));
            Assert.IsTrue(this.knight.ToString().Contains("Knight"));
        }
    }
}
