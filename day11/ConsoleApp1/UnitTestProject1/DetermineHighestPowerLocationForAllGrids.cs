using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class DetermineHighestPowerLocationForAllGrids
    {
        [TestMethod]
        public void Test1()
        {
            var result = Functions.DetermineHighestPowerLocationForAllGrids(18);
            Assert.AreEqual(90, result.Item1);
            Assert.AreEqual(269, result.Item2);
            Assert.AreEqual(16, result.Item3);
            Assert.AreEqual(113, result.Item4);
        }

        [TestMethod]
        public void Test2()
        {
            var result = Functions.DetermineHighestPowerLocationForAllGrids(42);
            Assert.AreEqual(232, result.Item1);
            Assert.AreEqual(251, result.Item2);
            Assert.AreEqual(12, result.Item3);
            Assert.AreEqual(119, result.Item4);

        }
    }
}
