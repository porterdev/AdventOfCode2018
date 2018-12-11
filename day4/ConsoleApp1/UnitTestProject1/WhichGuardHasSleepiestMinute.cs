using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class WhichGuardHasSleepiestMinute
    {
        [TestMethod]
        public void Test1()
        {
            //assume GetEvents is working as expected, because I'm too lazy to set up the data again :)
            var events = Functions.GetEvents(new GetEvents().SampleInput);

            var result = Functions.WhichGuardHasSleepiestMinute(events);

            Assert.AreEqual(99, result.Item1);
            Assert.AreEqual(45, result.Item2);
        }
    }
}
