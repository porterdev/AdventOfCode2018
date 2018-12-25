using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class ParseRule
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = "...## => #";
            var result = Functions.ParseRule(input);

            Assert.AreEqual("...##", result.Item1);
            Assert.IsTrue(result.Item2);

            input = ".#.#. => .";
            result = Functions.ParseRule(input);

            Assert.AreEqual(".#.#.", result.Item1);
            Assert.IsFalse(result.Item2);
        }
    }
}
