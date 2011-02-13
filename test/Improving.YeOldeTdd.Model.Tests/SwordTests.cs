namespace Improving.YeOldeTdd.Model.Tests
{
    using Improving.YeOldeTdd.Model.Entities;
    using Improving.YeOldeTdd.Model.Entities.Weapons;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SwordTests
    {
        [TestMethod]
        public void SwordDoesDamageWithinRange()
        {
            // We know the min and max attack values.
            int minDamage = 2;
            int maxDamage = 6;

            var sword = new Sword();
            Assert.IsTrue(minDamage <= sword.CalculateDamage());
            Assert.IsTrue(maxDamage >= sword.CalculateDamage());
        }
    }
}
