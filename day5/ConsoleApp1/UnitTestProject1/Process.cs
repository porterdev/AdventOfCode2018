using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Process
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = "dabAcCaCBAcCcaDA";
            var result = Functions.Process(input);

            var expected = "dabCBAcaDA";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "aAbBcCdDeE";
            var result = Functions.Process(input);

            var expected = "";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "AaBbCcDdEe";
            var result = Functions.Process(input);

            var expected = "";
            Assert.AreEqual(expected, result);
        }
    }
}
