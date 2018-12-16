using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class GetLargestArea
    {
        [TestMethod]
        public void Test1()
        {
            var points = new Dictionary<int, Point>
            {
                { 0, new Point(1, 1) },
                { 1, new Point(1, 6) },
                { 2, new Point(8, 3) },
                { 3, new Point(3, 4) },
                { 4, new Point(5, 5) },
                { 5, new Point(8, 9) },
            };

            var result = Functions.GetLargestArea(points);

            Assert.AreEqual(17, result);

        }
    }
}
