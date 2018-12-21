using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = "position=< 9,  1> velocity=< 0,  2>";

            var result = new Point(input);

            Assert.AreEqual(9, result.Position.Item1);
            Assert.AreEqual(1, result.Position.Item2);
            Assert.AreEqual(0, result.Velocity.Item1);
            Assert.AreEqual(2, result.Velocity.Item2);

            input = "position=<-9, -1> velocity=<-3, -2>";

            result = new Point(input);

            Assert.AreEqual(-9, result.Position.Item1);
            Assert.AreEqual(-1, result.Position.Item2);
            Assert.AreEqual(-3, result.Velocity.Item1);
            Assert.AreEqual(-2, result.Velocity.Item2);

            input = "position=< 52484, -20780> velocity=<-5,  2>";

            result = new Point(input);

            Assert.AreEqual(52484, result.Position.Item1);
            Assert.AreEqual(-20780, result.Position.Item2);
            Assert.AreEqual(-5, result.Velocity.Item1);
            Assert.AreEqual(2, result.Velocity.Item2);

            input = "position=<-52068,  31483> velocity=< 5, -3>";

            result = new Point(input);

            Assert.AreEqual(-52068, result.Position.Item1);
            Assert.AreEqual(31483, result.Position.Item2);
            Assert.AreEqual(5, result.Velocity.Item1);
            Assert.AreEqual(-3, result.Velocity.Item2);

        }

        [TestMethod]
        public void Test2()
        {
            var input = "position=< 3,  9> velocity=< 1,  -2>";
            var point = new Point(input);

            Assert.AreEqual(3, point.Position.Item1);
            Assert.AreEqual(9, point.Position.Item2);

            point.Iterate();

            Assert.AreEqual(4, point.Position.Item1);
            Assert.AreEqual(7, point.Position.Item2);

            point.Iterate();

            Assert.AreEqual(5, point.Position.Item1);
            Assert.AreEqual(5, point.Position.Item2);

            point.Iterate();

            Assert.AreEqual(6, point.Position.Item1);
            Assert.AreEqual(3, point.Position.Item2);
        }
    }
}
