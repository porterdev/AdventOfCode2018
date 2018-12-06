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

            var stringValues = readText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();

            //parse the input
            var claims = stringValues.Select(Functions.GetClaim).ToList();
            var duplicateCount = Functions.CountDuplicateClaims(claims);

            Console.WriteLine("Part 1: Duplicate Claims: {0}", duplicateCount);

            var claimsWithNoOverlap = Functions.GetClaimsWithNoOverlap(claims);

            Console.WriteLine("Claims with no overlap: {0}", claimsWithNoOverlap.Count);

            Console.WriteLine("Part 2: Claim ID: {0}", claimsWithNoOverlap[0].Id);

            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
