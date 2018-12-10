﻿using System;
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

            //now sort it because the date strings are all sortable
            stringValues.Sort();
            


            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
