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
            var walks = new List<List<int>>();
            var results = new List<int>();

            var firstMarble = new Marble { Value = 0 };
            firstMarble.Previous = firstMarble;
            firstMarble.Next = firstMarble;

            results.Add(0);
            walks.Add(firstMarble.Walk(true));

            var currentMarble = firstMarble;

            for (int i = 1; i <= 25; i++)
            {
                var result = Functions.PlayRound(i, ref currentMarble);
                results.Add(result);
                walks.Add(firstMarble.Walk(true));
            }

            var expectedResults = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 32, 0, 0};

            CollectionAssert.AreEqual(expectedResults, results);

            var expectedForwardWalks =
                new List<List<int>>
                {
                    new List<int> {0},
                    new List<int> {0, 1},
                    new List<int> {0, 2, 1},
                    new List<int> {0, 2, 1, 3},
                    new List<int> {0, 4, 2, 1, 3},
                    new List<int> {0, 4, 2, 5, 1, 3},
                    new List<int> {0, 4, 2, 5, 1, 6, 3},
                    new List<int> {0, 4, 2, 5, 1, 6, 3, 7},
                    new List<int> {0, 8, 4, 2, 5, 1, 6, 3, 7},
                    new List<int> {0, 8, 4, 9, 2, 5, 1, 6, 3, 7},
                    new List<int> {0, 8, 4, 9, 2, 10, 5, 1, 6, 3, 7},
                    new List<int> {0, 8, 4, 9, 2, 10, 5, 11, 1, 6, 3, 7},
                    new List<int> {0, 8, 4, 9, 2, 10, 5, 11, 1, 12, 6, 3, 7},
                    new List<int> {0, 8, 4, 9, 2, 10, 5, 11, 1, 12, 6, 13, 3, 7},
                    new List<int> {0, 8, 4, 9, 2, 10, 5, 11, 1, 12, 6, 13, 3, 14, 7},
                    new List<int> {0, 8, 4, 9, 2, 10, 5, 11, 1, 12, 6, 13, 3, 14, 7, 15},
                    new List<int> {0, 16, 8, 4, 9, 2, 10, 5, 11, 1, 12, 6, 13, 3, 14, 7, 15},
                    new List<int> {0, 16, 8, 17, 4, 9, 2, 10, 5, 11, 1, 12, 6, 13, 3, 14, 7, 15},
                    new List<int> {0, 16, 8, 17, 4, 18, 9, 2, 10, 5, 11, 1, 12, 6, 13, 3, 14, 7, 15},
                    new List<int> {0, 16, 8, 17, 4, 18, 9, 19, 2, 10, 5, 11, 1, 12, 6, 13, 3, 14, 7, 15},
                    new List<int> {0, 16, 8, 17, 4, 18, 9, 19, 2, 20, 10, 5, 11, 1, 12, 6, 13, 3, 14, 7, 15},
                    new List<int> {0, 16, 8, 17, 4, 18, 9, 19, 2, 20, 10, 21, 5, 11, 1, 12, 6, 13, 3, 14, 7, 15},
                    new List<int> {0, 16, 8, 17, 4, 18, 9, 19, 2, 20, 10, 21, 5, 22, 11, 1, 12, 6, 13, 3, 14, 7, 15},
                    new List<int> {0, 16, 8, 17, 4, 18, 19, 2, 20, 10, 21, 5, 22, 11, 1, 12, 6, 13, 3, 14, 7, 15},
                    new List<int> {0, 16, 8, 17, 4, 18, 19, 2, 24, 20, 10, 21, 5, 22, 11, 1, 12, 6, 13, 3, 14, 7, 15},
                    new List<int> {0, 16, 8, 17, 4, 18, 19, 2, 24, 20, 25, 10, 21, 5, 22, 11, 1, 12, 6, 13, 3, 14, 7, 15},
                };

            for (int i = 0; i <= 25; i++)
            {
                CollectionAssert.AreEqual(expectedForwardWalks[i], walks[i]);
            }
            
        }
    }
}
