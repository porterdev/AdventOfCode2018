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

        [TestMethod]
        public void TestMethod4()
        {
            var input = "dbcCCBcCcD";
            var result = Functions.Process(input);

            var expected = "dbCBcD";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = "daAcCaCAcCcaDA";
            var result = Functions.Process(input);

            var expected = "daCAcaDA";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var input = "dabAaBAaDA";
            var result = Functions.Process(input);

            var expected = "daDA";
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod7()
        {
            var input = "abAcCaCBAcCcaA";
            var result = Functions.Process(input);

            var expected = "abCBAc";
            Assert.AreEqual(expected, result);
        }
    }
}
