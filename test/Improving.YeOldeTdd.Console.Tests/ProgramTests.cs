namespace Improving.YeOldeTdd.Console.Tests
{
    using System;
    using System.IO;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestMenuOnSpecifyNullParameterThrowsException()
        {
            Program.SelectFromMenu(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestMenuOnSpecifyInvalidParameterThrowsException()
        {
            Program.SelectFromMenu("Z");
        }
    }
}
