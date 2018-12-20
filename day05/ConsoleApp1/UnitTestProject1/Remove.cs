using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class Remove
    {
        [TestMethod]
        public void Test1()
        {
            var input = "dabAcCaCBAcCcaDA";
            var result = Functions.Remove(input, 'a');

            Assert.AreEqual("dbcCCBcCcD", result);

            result = Functions.Remove(input, 'b');

            Assert.AreEqual("daAcCaCAcCcaDA", result);

            result = Functions.Remove(input, 'c');

            Assert.AreEqual("dabAaBAaDA", result);

            result = Functions.Remove(input, 'd');

            Assert.AreEqual("abAcCaCBAcCcaA", result);
        }
    }
}
