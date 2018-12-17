using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class GetSafeRegion
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

            var result = Functions.GetSafeRegion(points, 32);

            var expected = new bool[,]
            {
                { false, false, false, false, false, false, false, false, false, false},
                { false, false, false, false, false, false, false, false, false, false},
                { false, false, false, false,  true,  true, false, false, false, false},
                { false, false, false,  true,  true,  true,  true, false, false, false},
                { false, false, false,  true,  true,  true,  true, false, false, false},
                { false, false, false,  true,  true,  true,  true, false, false, false},
                { false, false, false, false,  true,  true, false, false, false, false},
                { false, false, false, false, false, false, false, false, false, false},
                { false, false, false, false, false, false, false, false, false, false},
            };


            Assert.AreEqual(expected.GetLength(0), result.GetLength(0));
            Assert.AreEqual(expected.GetLength(1), result.GetLength(1));

            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.AreEqual(expected[i, j], result[i, j]);
                }
            }
        }
    }
}
