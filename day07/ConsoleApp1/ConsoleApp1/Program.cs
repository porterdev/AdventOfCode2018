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

            var rules = Functions.ProcessRules(input);

            var result = Functions.DetermineExecutionOrder(rules);

            Console.WriteLine("Part 1: execution order: {0}", result);

            rules = Functions.ProcessRules(input);
            var timeTaken = Functions.DetermineExecutionTime(rules, 5, 60);

            Console.WriteLine("Part 2: timeTaken: {0}", timeTaken);

            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
