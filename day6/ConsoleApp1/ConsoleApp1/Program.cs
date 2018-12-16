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

            var input = readText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();

            var points = Functions.GetPoints(input);

            var largestArea = Functions.GetLargestArea(points);

            Console.WriteLine("Part 1: Largest Area: {0}", largestArea);
           
            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
