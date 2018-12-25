using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class ApplyRulesForXIterations
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

            //pad initial state left and right with enough "." to cover our iterations
            var state = "#..#.#..##......###...###";
            var pad = new string('.', 20);
            state = pad + state + pad;

            var result = Functions.ApplyRulesForXIterations(rules, state, 20);

            //this starts from index -3
            var expected = ".#....##....#####...#######....#.#..##.";

            Assert.IsTrue(result.Contains(expected));
            Assert.AreEqual(17, result.IndexOf(expected));
        }
    }
}
