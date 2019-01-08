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

            //for part 2, it will take too long to compute 50000000000 generations.
            //instead, let's see if we can identify a pattern

            //compute the first n values
            var n = 200;
            var newState = "##...#......##......#.####.##.#..#..####.#.######.##..#.####...##....#.#.####.####.#..#.######.##...";
            pad = new string('.', n);
            newState = pad + newState + pad;

            value = Functions.DetermineStateValue(newState, -n);
            var values = new List<int> {value};

            for (int i = 0; i < n; i++)
            {
                newState = Functions.ApplyRulesForXIterations(rules, newState, 1);
                value = Functions.DetermineStateValue(newState, -n);
                values.Add(value);
            }

            var prev = 0;
            for (int i = 0; i < values.Count; i++)
            {
                Console.WriteLine("{0}: {1} ({2})", i, values[i], values[i] - prev);
                prev = values[i];
            }

            //it appears that from iteration 100: 6295 (51), we are adding 51 each time
            // hence formula to solve after n iterations is
            // result = 6295 + (51 * (n-100))

            var part2 = 6295 + (51 * (50000000000 - 100));

            Console.WriteLine("Part 2: Value:{0}", part2);

            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
