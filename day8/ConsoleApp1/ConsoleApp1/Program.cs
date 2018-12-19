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
         

            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
