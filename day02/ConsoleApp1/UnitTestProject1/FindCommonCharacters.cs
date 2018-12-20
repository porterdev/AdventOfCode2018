using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class FindCommonCharacters
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
            //initial examples
            var result = _functions.FindCommonCharacters("abcde", "axcye");
            Assert.AreEqual("ace", result);

            result = _functions.FindCommonCharacters("fghij", "fguij");
            Assert.AreEqual("fgij", result);

            // all differ, all different chars
            result = _functions.FindCommonCharacters("abcde", "fghij");
            Assert.AreEqual("", result);

            // all differ, same chars, different order
            result = _functions.FindCommonCharacters("abcde", "bcdea");
            Assert.AreEqual("", result);

            // 1 character differs
            result = _functions.FindCommonCharacters("abcde", "fbcde");
            Assert.AreEqual("bcde", result);

            result = _functions.FindCommonCharacters("abcde", "afcde");
            Assert.AreEqual("acde", result);

            result = _functions.FindCommonCharacters("abcde", "abfde");
            Assert.AreEqual("abde", result);

            result = _functions.FindCommonCharacters("abcde", "abcfe");
            Assert.AreEqual("abce", result);

            result = _functions.FindCommonCharacters("abcde", "abcdf");
            Assert.AreEqual("abcd", result);

            // 2 characters differ
            result = _functions.FindCommonCharacters("abcde", "ffcde");
            Assert.AreEqual("cde", result);

            result = _functions.FindCommonCharacters("abcde", "affde");
            Assert.AreEqual("ade", result);

            result = _functions.FindCommonCharacters("abcde", "abffe");
            Assert.AreEqual("abe", result);

            result = _functions.FindCommonCharacters("abcde", "abcff");
            Assert.AreEqual("abc", result);

            // 3 characters differ
            result = _functions.FindCommonCharacters("abcde", "fffde");
            Assert.AreEqual("de", result);

            result = _functions.FindCommonCharacters("abcde", "afffe");
            Assert.AreEqual("ae", result);

            result = _functions.FindCommonCharacters("abcde", "abfff");
            Assert.AreEqual("ab", result);

            // 4 characters differ
            result = _functions.FindCommonCharacters("abcde", "ffffe");
            Assert.AreEqual("e", result);

            result = _functions.FindCommonCharacters("abcde", "affff");
            Assert.AreEqual("a", result);

        }
    }
}
