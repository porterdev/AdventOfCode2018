using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class GetCheckSum
    {
        private Functions _functions;

        [TestInitialize]
        public void Init()
        {
            _functions = new Functions();
        }

        [TestCleanup]
        public void Cleanup()
        {

        }

        [TestMethod]
        public void Test1()
        {
            var strings = new List<string>
            {
                "abcdef",
                "bababc",
                "abbcde",
                "abcccd",
                "aabcdd",
                "abcdee",
                "ababab",
            };
            var result = _functions.GetCheckSum(strings);

            Assert.AreEqual(12, result);
        }
    }
}
