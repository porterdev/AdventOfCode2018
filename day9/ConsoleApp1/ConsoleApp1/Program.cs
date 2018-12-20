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

            //ensure we have trimmed
            readText = readText.Trim();

            var gameSetup = new GameSetup(readText);

            Console.WriteLine("Game Setup: {0} players, {1} points", gameSetup.Players, gameSetup.Points);

            var result = Functions.PlayGame(gameSetup.Players, gameSetup.Points);
            var topScore = result.Max();

            Console.WriteLine("Part 1: Top Score: {0}", topScore);


            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
