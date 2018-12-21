using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var result = Functions.DetermineHighestPowerLocation(8868);

            Console.WriteLine("Part 1: ({0},{1}) with power level {2}", result.Item1, result.Item2, result.Item3);

            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
