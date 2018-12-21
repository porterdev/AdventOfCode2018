using System;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //load the input
            string readText = File.ReadAllText("input.txt");

            //ensure we have trimmed
            readText = readText.Trim();

            var split = Environment.NewLine;
            if (!readText.Contains(Environment.NewLine))
            {
                split = "\n";
            }
            var input = readText.Split(split, StringSplitOptions.RemoveEmptyEntries).ToList();

            var points = input.Select(x => new Point(x)).ToList();

            var iterations = Functions.IterateToSmallestArea(points, 5824);

            Console.WriteLine("Part 1: This took {0} iterations", iterations);

            var lines = Functions.Visualize(points);

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("");

            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
