using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ParseRule
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = "Step C must be finished before step A can begin.";
            var result = Functions.ParseRule(input);

            Assert.AreEqual('C', result.Item1);
            Assert.AreEqual('A', result.Item2);

            input = "Step A must be finished before step B can begin.";
            result = Functions.ParseRule(input);

            Assert.AreEqual('A', result.Item1);
            Assert.AreEqual('B', result.Item2);


        }
    }
}

