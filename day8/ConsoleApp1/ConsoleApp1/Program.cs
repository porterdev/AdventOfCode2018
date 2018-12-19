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

            var input = readText.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            var numbers = input.Select(Int32.Parse).ToList();

            var index = 0;
            var tree = Functions.GetTree(numbers, ref index);

            var sumMetadata = Functions.GetSumMetadata(tree);

            Console.WriteLine("Part 1: Sum of Metadata: {0}", sumMetadata);
            
            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
