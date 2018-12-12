using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class GetShortestPolymer
    {
        [TestMethod]
        public void Test1()
        {
            var input = "dabAcCaCBAcCcaDA";
            var result = Functions.GetShortestPolymer(input);

            var expected = "daDA";
            Assert.AreEqual(expected, result);
        }
    }
}
