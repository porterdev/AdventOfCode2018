using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class GetSumMetadata
    {
        [TestMethod]
        public void Test1()
        {
            var input = new List<int> { 2, 3, 0, 3, 10, 11, 12, 1, 1, 0, 1, 99, 2, 1, 1, 2 };

            var index = 0;
            var tree = Functions.GetTree(input, ref index);

            var result = Functions.GetSumMetadata(tree);

            Assert.AreEqual(138, result);
        }
    }
}
