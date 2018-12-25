using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class DetermineStateValue
    {
        [TestMethod]
        public void Test1()
        {
            var state = ".#....##....#####...#######....#.#..##.";

            var result = Functions.DetermineStateValue(state, -3);

            Assert.AreEqual(325, result);
        }
    }
}
