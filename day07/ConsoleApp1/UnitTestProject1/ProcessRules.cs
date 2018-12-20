using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class ProcessRules
    {
        [TestMethod]
        public void Test1()
        {
            var inputs = new List<string>
            {
                "Step C must be finished before step A can begin.",
                "Step C must be finished before step F can begin.",
                "Step A must be finished before step B can begin.",
                "Step A must be finished before step D can begin.",
                "Step B must be finished before step E can begin.",
                "Step D must be finished before step E can begin.",
                "Step F must be finished before step E can begin.",
            };

            var result = Functions.ProcessRules(inputs);

            Assert.AreEqual(6, result.Count);

            CollectionAssert.AreEqual(new char[] { 'C' }, result['A'].Requires);

            CollectionAssert.AreEqual(new char[] { 'A' }, result['B'].Requires);

            CollectionAssert.AreEqual(new char[] { }, result['C'].Requires);

            CollectionAssert.AreEqual(new char[] { 'A' }, result['D'].Requires);

            CollectionAssert.AreEqual(new char[] { 'B', 'D', 'F' }, result['E'].Requires);

            CollectionAssert.AreEqual(new char[] { 'C' }, result['F'].Requires);
        }
    }
}
