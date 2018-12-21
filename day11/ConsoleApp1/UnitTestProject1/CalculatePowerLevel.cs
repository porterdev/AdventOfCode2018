using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CalculatePowerLevel
    {
        [TestMethod]
        public void TestMethod1()
        {
            var result = Functions.CalculatePowerLevel(3, 5, 8);
            Assert.AreEqual(4, result);

            result = Functions.CalculatePowerLevel(122, 79, 57);
            Assert.AreEqual(-5, result);

            result = Functions.CalculatePowerLevel(217, 196, 39);
            Assert.AreEqual(0, result);

            result = Functions.CalculatePowerLevel(101, 153, 71);
            Assert.AreEqual(4, result);
        }
    }
}
