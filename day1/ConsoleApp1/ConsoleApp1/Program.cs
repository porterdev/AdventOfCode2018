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

            var stringValues = readText.Split(Environment.NewLine);

            var values = stringValues.Select(int.Parse).ToList();

            var sum = values.Sum();

            var functions = new Functions();
            var result = functions.FindFirstFrequencyReachedTwice(values);

            Console.WriteLine("Part 1: Sum is {0}", sum);
            Console.WriteLine("Part 2: answer is {0}", result);

            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
