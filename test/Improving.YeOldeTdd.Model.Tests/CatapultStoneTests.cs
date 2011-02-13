namespace Improving.YeOldeTdd.Model.Tests
{
    using Improving.YeOldeTdd.Model.Entities.Weapons;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CatapultStoneTests
    {
        [TestMethod]
        public void CatapultStoneDoesDamageWithinRange()
        {
            // We know the catapult has minimum damage 10, maximum damage 25.
            int minDamage = 10;
            int maxDamage = 25;

            var stone = new CatapultStone();
            Assert.IsTrue(minDamage <= stone.CalculateDamage());
            Assert.IsTrue(maxDamage >= stone.CalculateDamage());
        }
    }
}
