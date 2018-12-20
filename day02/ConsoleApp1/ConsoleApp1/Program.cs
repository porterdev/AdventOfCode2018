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

            var functions = new Functions();
            var result = functions.GetCheckSum(stringValues);

            Console.WriteLine("Part 1: checksum value is {0}", result);

            var correctBoxes = functions.FindTwoCorrectBoxes(stringValues);
            var commonChars = functions.FindCommonCharacters(correctBoxes[0], correctBoxes[1]);

            Console.WriteLine("Part 2: common chars of the correct boxes: {0}", commonChars);


            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
