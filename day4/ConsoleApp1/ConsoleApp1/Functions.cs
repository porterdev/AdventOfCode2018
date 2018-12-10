using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class Functions
    {
        public static List<Event> GetEvents(List<string> input)
        {
            var events = new List<Event>();

            //loop through the input
            foreach (var item in input)
            {
                //identify when we find a new event [1518-11-22 00:00] Guard #1231 begins shift
                //identify when guard falls asleep [1518-04-13 00:00] falls asleep
                //identify when guard wakes [1518-04-06 00:58] wakes up
            }

            return events;
        }
    }
}
