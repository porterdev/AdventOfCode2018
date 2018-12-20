using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class PlayRound
    {
        [TestMethod]
        public void Test1()
        {
            //0 (1)
            var currentMarble = new Marble {Value = 0};
            currentMarble.Previous = currentMarble;
            currentMarble.Next = currentMarble;
            var result = Functions.PlayRound(1, ref currentMarble);

            Assert.AreEqual(0, result);
            CollectionAssert.AreEqual(new List<int> {1, 0}, currentMarble.Walk(true));
            CollectionAssert.AreEqual(new List<int> {1, 0}, currentMarble.Walk(false));

        }

        [TestMethod]
        public void Test2()
        {
            //0 (2) 1 
            var currentMarble = new Marble { Value = 0 };
            currentMarble.Previous = currentMarble;
            currentMarble.Next = currentMarble;

            var result = 0;
            for (int i = 1; i <= 2; i++)
            {
                result = Functions.PlayRound(i, ref currentMarble);
            }

            Assert.AreEqual(0, result);
            CollectionAssert.AreEqual(new List<int> { 2, 1, 0 }, currentMarble.Walk(true));
            CollectionAssert.AreEqual(new List<int> { 2, 0, 1 }, currentMarble.Walk(false));

        }

        [TestMethod]
        public void Test3()
        {
            var forwardWalks = new List<List<int>>();
            var backwardWalks = new List<List<int>>();
            var results = new List<int>();

            var currentMarble = new Marble { Value = 0 };
            currentMarble.Previous = currentMarble;
            currentMarble.Next = currentMarble;

            results.Add(0);
            forwardWalks.Add(currentMarble.Walk(true));
            backwardWalks.Add(currentMarble.Walk(false));

            for (int i = 1; i <= 25; i++)
            {
                var result = Functions.PlayRound(i, ref currentMarble);
                results.Add(result);
                forwardWalks.Add(currentMarble.Walk(true));
                backwardWalks.Add(currentMarble.Walk(false));
            }

            var expectedResults = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 32, 0, 0};

            CollectionAssert.AreEqual(expectedResults, results);

            var expectedForwardWalks =
                new List<List<int>>
                {
                    new List<int> {0},
                    new List<int> {1, 0},
                    new List<int> {2, 0, 1},
                    //continue for remaining walks up to 25
                };

            var expectedBackwardsWalks =
                new List<List<int>>
                {
                    new List<int> {0},
                    new List<int> {1, 0},
                    new List<int> {2, 1, 0}
                    //continue for remaining walks up to 25
                };
        }
    }
}
