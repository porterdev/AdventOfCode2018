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


           

            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
