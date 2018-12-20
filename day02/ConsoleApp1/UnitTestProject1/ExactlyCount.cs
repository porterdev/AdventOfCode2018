using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ExactlyCount
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
            Assert.IsFalse(_functions.ExactlyCount("abcdef", 2));
            Assert.IsFalse(_functions.ExactlyCount("abcdef", 3));

            Assert.IsTrue(_functions.ExactlyCount("bababc", 2));
            Assert.IsTrue(_functions.ExactlyCount("bababc", 3));

            Assert.IsTrue(_functions.ExactlyCount("abbcde", 2));
            Assert.IsFalse(_functions.ExactlyCount("abbcde", 3));

            Assert.IsFalse(_functions.ExactlyCount("abcccd", 2));
            Assert.IsTrue(_functions.ExactlyCount("abcccd", 3));

            Assert.IsTrue(_functions.ExactlyCount("aabcdd", 2));
            Assert.IsFalse(_functions.ExactlyCount("aabcdd", 3));

            Assert.IsTrue(_functions.ExactlyCount("abcdee", 2));
            Assert.IsFalse(_functions.ExactlyCount("abcdee", 3));

            Assert.IsFalse(_functions.ExactlyCount("ababab", 2));
            Assert.IsTrue(_functions.ExactlyCount("ababab", 3));
        }


    }
}
