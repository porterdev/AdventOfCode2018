using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // set up our rules
            var rules = new List<Tuple<string, bool>>
            {
                new Tuple<string, bool>("#....", false),
                new Tuple<string, bool>("#..##", true),
                new Tuple<string, bool>("....#", false),
                new Tuple<string, bool>("...#.", false),
                new Tuple<string, bool>("...##", true),
                new Tuple<string, bool>("#.#.#", false),
                new Tuple<string, bool>(".#...", true),
                new Tuple<string, bool>("##.#.", false),
                new Tuple<string, bool>("..#.#", false),
                new Tuple<string, bool>(".##.#", true),
                new Tuple<string, bool>("###.#", true),
                new Tuple<string, bool>(".#.##", false),
                new Tuple<string, bool>(".....", false),
                new Tuple<string, bool>("#####", true),
                new Tuple<string, bool>("###..", false),
                new Tuple<string, bool>("##..#", true),
                new Tuple<string, bool>("#.###", true),
                new Tuple<string, bool>("#.#..", false),
                new Tuple<string, bool>("..###", false),
                new Tuple<string, bool>("..#..", false),
                new Tuple<string, bool>(".#..#", true),
                new Tuple<string, bool>(".##..", true),
                new Tuple<string, bool>("##...", true),
                new Tuple<string, bool>(".#.#.", true),
                new Tuple<string, bool>(".###.", true),
                new Tuple<string, bool>("#..#.", false),
                new Tuple<string, bool>("####.", false),
                new Tuple<string, bool>(".####", true),
                new Tuple<string, bool>("#.##.", true),
                new Tuple<string, bool>("##.##", false),
                new Tuple<string, bool>("..##.", false),
                new Tuple<string, bool>("#...#", true)
            };

            //pad initial state left and right with enough "." to cover our iterations
            var state = "##...#......##......#.####.##.#..#..####.#.######.##..#.####...##....#.#.####.####.#..#.######.##...";
            var pad = new string('.', 20);
            state = pad + state + pad;

            var result = Functions.ApplyRulesForXIterations(rules, state, 20);

            var value = Functions.DetermineStateValue(result, -20);

            Console.WriteLine("Part 1: Value:{0}", value);

            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
