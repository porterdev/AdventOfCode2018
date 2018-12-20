using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class WalkTest
    {
        [TestMethod]
        public void Test0_Forwards()
        {
            var currentMarble = Utils.BuildCircle(0);

            var result = currentMarble.Walk(true);

            var expected = new List<int> {0};

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test0_Backwards()
        {
            var currentMarble = Utils.BuildCircle(0);

            var result = currentMarble.Walk(false);

            var expected = new List<int> { 0 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test1_Forwards()
        {
            var currentMarble = Utils.BuildCircle(1);

            var result = currentMarble.Walk(true);

            var expected = new List<int> { 0, 1 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test1_Backwards()
        {
            var currentMarble = Utils.BuildCircle(1);

            var result = currentMarble.Walk(false);

            var expected = new List<int> { 0, 1 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test2_Forwards()
        {
            var currentMarble = Utils.BuildCircle(2);

            var result = currentMarble.Walk(true);

            var expected = new List<int> { 0, 1, 2 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test2_Backwards()
        {
            var currentMarble = Utils.BuildCircle(2);

            var result = currentMarble.Walk(false);

            var expected = new List<int> { 0, 2, 1 };

            CollectionAssert.AreEqual(expected, result);
        }

    }
}
