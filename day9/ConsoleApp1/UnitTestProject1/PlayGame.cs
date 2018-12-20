using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class PlayGame
    {
        [TestMethod]
        public void Test1()
        {
            var result = Functions.PlayGame(9, 25);

            var expected = new List<int> { 0, 0, 0, 0, 32, 0, 0, 0, 0 };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Test2()
        {
            // 10 players; last marble is worth 1618 points: high score is 8317
            var result = Functions.PlayGame(10, 1618);
            Assert.AreEqual(8317, result.Max());

            // 13 players; last marble is worth 7999 points: high score is 146373
            result = Functions.PlayGame(13, 7999);
            Assert.AreEqual(146373, result.Max());

            // 17 players; last marble is worth 1104 points: high score is 2764
            result = Functions.PlayGame(17, 1104);
            Assert.AreEqual(2764, result.Max());

            // 21 players; last marble is worth 6111 points: high score is 54718
            result = Functions.PlayGame(21, 6111);
            Assert.AreEqual(54718, result.Max());

            // 30 players; last marble is worth 5807 points: high score is 37305
            result = Functions.PlayGame(30, 5807);
            Assert.AreEqual(37305, result.Max());


        }
    }
}
