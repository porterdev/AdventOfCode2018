using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class GetEvents
    {
        public List<string> SampleInput = new List<string>
            {
                "[1518-11-01 00:00] Guard #10 begins shift",
                "[1518-11-01 00:05] falls asleep",
                "[1518-11-01 00:25] wakes up",
                "[1518-11-01 00:30] falls asleep",
                "[1518-11-01 00:55] wakes up",
                "[1518-11-01 23:58] Guard #99 begins shift",
                "[1518-11-02 00:40] falls asleep",
                "[1518-11-02 00:50] wakes up",
                "[1518-11-03 00:05] Guard #10 begins shift",
                "[1518-11-03 00:24] falls asleep",
                "[1518-11-03 00:29] wakes up",
                "[1518-11-04 00:02] Guard #99 begins shift",
                "[1518-11-04 00:36] falls asleep",
                "[1518-11-04 00:46] wakes up",
                "[1518-11-05 00:03] Guard #99 begins shift",
                "[1518-11-05 00:45] falls asleep",
                "[1518-11-05 00:55] wakes up"
            };

        [TestMethod]
        public void Test1()
        {
            
            var result = Functions.GetEvents(SampleInput);

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count);

            //--------------------------------------
            var event1 = result[0];
            Assert.AreEqual(10, event1.Id);
            Assert.AreEqual(new DateTime(1518, 11, 01), event1.Date);

            var asleep = Enumerable.Range(0, 59)
             .Where(i => event1.Asleep[i])
             .ToList();

            var expected = new List<int>();
            expected.AddRange(Enumerable.Range(5, 20)); //5 to 24
            expected.AddRange(Enumerable.Range(30, 25)); //30 to 54

            CollectionAssert.AreEqual(expected, asleep);

            //--------------------------------------
            var event2 = result[1];
            Assert.AreEqual(99, event2.Id);
            Assert.AreEqual(new DateTime(1518, 11, 02), event2.Date);

            asleep = Enumerable.Range(0, 59)
             .Where(i => event2.Asleep[i])
             .ToList();

            expected = new List<int>();
            expected.AddRange(Enumerable.Range(40, 10)); //40 to 49

            CollectionAssert.AreEqual(expected, asleep);

            //--------------------------------------
            var event3 = result[2];
            Assert.AreEqual(10, event3.Id);
            Assert.AreEqual(new DateTime(1518, 11, 03), event3.Date);

            asleep = Enumerable.Range(0, 59)
             .Where(i => event3.Asleep[i])
             .ToList();

            expected = new List<int>();
            expected.AddRange(Enumerable.Range(24, 5)); //24 to 28

            CollectionAssert.AreEqual(expected, asleep);

            //--------------------------------------
            var event4 = result[3];
            Assert.AreEqual(99, event4.Id);
            Assert.AreEqual(new DateTime(1518, 11, 04), event4.Date);

            asleep = Enumerable.Range(0, 59)
             .Where(i => event4.Asleep[i])
             .ToList();

            expected = new List<int>();
            expected.AddRange(Enumerable.Range(36, 10)); //36 to 45

            CollectionAssert.AreEqual(expected, asleep);

            //--------------------------------------
            var event5 = result[4];
            Assert.AreEqual(99, event5.Id);
            Assert.AreEqual(new DateTime(1518, 11, 05), event5.Date);

            asleep = Enumerable.Range(0, 59)
             .Where(i => event5.Asleep[i])
             .ToList();

            expected = new List<int>();
            expected.AddRange(Enumerable.Range(45, 10)); //45 to 54

            CollectionAssert.AreEqual(expected, asleep);

        }
    }
}
