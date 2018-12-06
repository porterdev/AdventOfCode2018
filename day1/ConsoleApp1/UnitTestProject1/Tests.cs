using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
using Microsoft.VisualBasic.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Tests
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
        public void Example1()
        {
            //+1, -1 first reaches 0 twice.
            var values = new List<int> { 1, -1 };
            var result = _functions.FindFirstFrequencyReachedTwice(values);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Example2()
        {
            //+3, +3, +4, -2, -4 first reaches 10 twice.
            var values = new List<int> { +3, +3, +4, -2, -4 };
            var result = _functions.FindFirstFrequencyReachedTwice(values);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Example3()
        {
            //-6, +3, +8, +5, -6 first reaches 5 twice.
            var values = new List<int> { -6, +3, +8, +5, -6 };
            var result = _functions.FindFirstFrequencyReachedTwice(values);
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Example4()
        {
            //+7, +7, -2, -7, -4 first reaches 14 twice.
            var values = new List<int> { +7, +7, -2, -7, -4 };
            var result = _functions.FindFirstFrequencyReachedTwice(values);
            Assert.AreEqual(14, result);
        }
    }
}
