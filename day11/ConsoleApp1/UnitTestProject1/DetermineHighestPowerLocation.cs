using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class DetermineHighestPowerLocation
    {
        [TestMethod]
        public void Test1()
        {
            var result = Functions.DetermineHighestPowerLocation(18);
            Assert.AreEqual(33, result.Item1);
            Assert.AreEqual(45, result.Item2);
            Assert.AreEqual(29, result.Item3);

            result = Functions.DetermineHighestPowerLocation(42);
            Assert.AreEqual(21, result.Item1);
            Assert.AreEqual(61, result.Item2);
            Assert.AreEqual(30, result.Item3);
        }
    }
}
