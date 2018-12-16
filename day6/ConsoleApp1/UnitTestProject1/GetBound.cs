using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class GetBound
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

            var result = Functions.GetBound(points);

            var expected = new Int32[,]
            {
                { 0, 0, 0, 0,-1, 1, 1, 1, 1, 1},
                { 0, 0, 0, 0,-1, 1, 1, 1, 1, 1},
                { 0, 0, 0, 3, 3,-1, 1, 1, 1, 1},
                { 0, 0, 3, 3, 3, 3,-1,-1,-1,-1},
                { 0, 0, 3, 3, 3, 4, 4, 4, 4, 5},
                {-1,-1, 4, 4, 4, 4, 4, 4, 4, 5},
                { 2, 2, 2, 2, 4, 4, 4, 4, 5, 5},
                { 2, 2, 2, 2, 2, 4, 4, 5, 5, 5},
                { 2, 2, 2, 2, 2, 2,-1, 5, 5, 5}
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
