using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class GetPoints
    {
        [TestMethod]
        public void TestMethod1()
        {
            var points = new List<string>
            {
                "1, 1",
                "1, 6",
                "8, 3",
                "3, 4",
                "5, 5",
                "8, 9"
            };

            var result = Functions.GetPoints(points);

            Assert.AreEqual(6, result.Count);

            Assert.AreEqual(1, result[0].X);
            Assert.AreEqual(1, result[0].Y);

            Assert.AreEqual(1, result[1].X);
            Assert.AreEqual(6, result[1].Y);

            Assert.AreEqual(8, result[2].X);
            Assert.AreEqual(3, result[2].Y);

            Assert.AreEqual(3, result[3].X);
            Assert.AreEqual(4, result[3].Y);

            Assert.AreEqual(5, result[4].X);
            Assert.AreEqual(5, result[4].Y);

            Assert.AreEqual(8, result[5].X);
            Assert.AreEqual(9, result[5].Y);

        }
    }
}
