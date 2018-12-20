using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CompareStrings
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
            var result = _functions.CompareStrings("abcde", "axcye");
            Assert.AreEqual(2, result);

            result = _functions.CompareStrings("fghij", "fguij");
            Assert.AreEqual(1, result);

            // all differ, all different chars
            result = _functions.CompareStrings("abcde", "fghij");
            Assert.AreEqual(5, result);

            // all differ, same chars, different order
            result = _functions.CompareStrings("abcde", "bcdea");
            Assert.AreEqual(5, result);

            // 1 character differs
            result = _functions.CompareStrings("abcde", "fbcde");
            Assert.AreEqual(1, result);

            result = _functions.CompareStrings("abcde", "afcde");
            Assert.AreEqual(1, result);

            result = _functions.CompareStrings("abcde", "abfde");
            Assert.AreEqual(1, result);

            result = _functions.CompareStrings("abcde", "abcfe");
            Assert.AreEqual(1, result);

            result = _functions.CompareStrings("abcde", "abcdf");
            Assert.AreEqual(1, result);

            // 2 characters differ
            result = _functions.CompareStrings("abcde", "ffcde");
            Assert.AreEqual(2, result);

            result = _functions.CompareStrings("abcde", "affde");
            Assert.AreEqual(2, result);

            result = _functions.CompareStrings("abcde", "abffe");
            Assert.AreEqual(2, result);

            result = _functions.CompareStrings("abcde", "abcff");
            Assert.AreEqual(2, result);

            // 3 characters differ
            result = _functions.CompareStrings("abcde", "fffde");
            Assert.AreEqual(3, result);

            result = _functions.CompareStrings("abcde", "afffe");
            Assert.AreEqual(3, result);

            result = _functions.CompareStrings("abcde", "abfff");
            Assert.AreEqual(3, result);

            // 4 characters differ
            result = _functions.CompareStrings("abcde", "ffffe");
            Assert.AreEqual(4, result);

            result = _functions.CompareStrings("abcde", "affff");
            Assert.AreEqual(4, result);

        }
    }
}
