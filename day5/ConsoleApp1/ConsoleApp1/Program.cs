using System;
using System.IO;

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

            var result = Functions.Process(readText);

            Console.WriteLine("Part 1: resulting string has length {0}", result.Length);

            var result2 = Functions.GetShortestPolymer(readText);

            Console.WriteLine("Part 2: resulting string has length {0}", result2.Length);

            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
