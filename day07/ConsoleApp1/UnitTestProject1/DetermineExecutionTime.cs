using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class DetermineExecutionTime
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

            var rules = Functions.ProcessRules(inputs);

            var result = Functions.DetermineExecutionTime(rules, 2, 0);

            Assert.AreEqual(15, result);
        }
    }
}
