using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var result = Functions.DetermineHighestPowerLocation(8868, 3);

            Console.WriteLine("Part 1: ({0},{1}) with power level {2}", result.Item1, result.Item2, result.Item3);

            var result2 = Functions.DetermineHighestPowerLocationForAllGrids(8868);

            Console.WriteLine("Part 2: ({0},{1},{2}) with power level {3}", result2.Item1, result2.Item2, result2.Item3, result2.Item4);

            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
