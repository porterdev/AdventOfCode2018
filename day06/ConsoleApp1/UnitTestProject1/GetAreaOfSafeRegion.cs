using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class GetAreaOfSafeRegion
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

            var result = Functions.GetAreaOfSafeRegion(points, 32);

            Assert.AreEqual(16, result);
        }
    }
}
