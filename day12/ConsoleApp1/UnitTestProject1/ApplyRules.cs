using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class ApplyRules
    {
        [TestMethod]
        public void Test1()
        {
            var rules = new List<Tuple<string, bool>>
            {
                new Tuple<string, bool>("...##", true),
                new Tuple<string, bool>("..#..", true),
                new Tuple<string, bool>(".#...", true),
                new Tuple<string, bool>(".#.#.", true),
                new Tuple<string, bool>(".#.##", true),
                new Tuple<string, bool>(".##..", true),
                new Tuple<string, bool>(".####", true),
                new Tuple<string, bool>("#.#.#", true),
                new Tuple<string, bool>("#.###", true),
                new Tuple<string, bool>("##.#.", true),
                new Tuple<string, bool>("##.##", true),
                new Tuple<string, bool>("###..", true),
                new Tuple<string, bool>("###.#", true),
                new Tuple<string, bool>("####.", true)
            };

            var state = "...#..#.#..##......###...###...........";

            var result = Functions.ApplyRules(rules, state);

            var expected = "...#...#....#.....#..#..#..#...........";

            Assert.AreEqual(expected, result);

            var result2 = Functions.ApplyRules(rules, result);

            var expected2 = "...##..##...##....#..#..#..##..........";

            Assert.AreEqual(expected2, result2);
        }
    }
}
