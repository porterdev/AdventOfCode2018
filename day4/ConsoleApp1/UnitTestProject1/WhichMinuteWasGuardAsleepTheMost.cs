using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class WhichMinuteWasGuardAsleepTheMost
    {
        [TestMethod]
        public void Test1()
        {
            //assume GetEvents is working as expected, because I'm too lazy to set up the data again :)
            var events = Functions.GetEvents(new GetEvents().SampleInput);

            var result = Functions.WhichMinuteWasGuardAsleepTheMost(10, events);

            Assert.AreEqual(24, result);
        }
    }
}
