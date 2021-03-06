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

            var events = Functions.GetEvents(stringValues);

            var guardId = Functions.GuardWithMostMinutesAsleep(events);

            var minuteAsleep = Functions.WhichMinuteWasGuardAsleepTheMost(guardId, events);

            Console.WriteLine("Guard {0} was asleep the most, during minute {1}", guardId, minuteAsleep);

            Console.WriteLine("Part 1: {0}x{1}={2}", guardId, minuteAsleep, guardId * minuteAsleep);

            var sleepiestMinute = Functions.WhichGuardHasSleepiestMinute(events);

            Console.WriteLine("Guard {0} had the sleepiest minute, during minute {1}", sleepiestMinute.Item1, sleepiestMinute.Item2);

            Console.WriteLine("Part 2: {0}x{1}={2}", sleepiestMinute.Item1, sleepiestMinute.Item2, sleepiestMinute.Item1 * sleepiestMinute.Item2);

            Console.WriteLine("end!");
            Console.ReadLine();
        }
    }
}
