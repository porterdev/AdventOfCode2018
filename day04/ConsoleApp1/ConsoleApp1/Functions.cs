using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public static class Functions
    {
        public static List<Event> GetEvents(List<string> input)
        {
            var events = new List<Event>();

            var e = new Event();
            var first = true;
            var fallAsleep = 0;
            var wakes = 0;

            //loop through the input
            foreach (var item in input)
            {
                //every row starts with a date/time
                var dateString = item.Substring(1, 16);
                var date = DateTime.Parse(dateString);

                var theRest = item.Substring(19);

                //identify when we find a new event [1518-11-22 00:00] Guard #1231 begins shift
                //identify when guard falls asleep [1518-04-13 00:00] falls asleep
                //identify when guard wakes [1518-04-06 00:58] wakes up
                if (theRest.StartsWith("Guard"))
                {
                    if (!first)
                    {
                        events.Add(e);
                    }

                    //new guard, new shift
                    if (date.Hour == 23)
                    {
                        //guard started before midnight, so add a day
                        date = date.AddDays(1);
                    }

                    Regex regex = new Regex("^Guard #(\\d*) begins shift$");
                    Match match = regex.Match(theRest);
                    var id = match.Groups[1].Value;

                    e = new Event { Date = date.Date, Id = Int64.Parse(id) };
                    first = false;
                    fallAsleep = 0;
                    wakes = 0;

                }
                else if (theRest.StartsWith("falls"))
                {
                    // start fall asleep period
                    fallAsleep = date.Minute;
                }
                else if (theRest.StartsWith("wakes"))
                {
                    //start wake period
                    wakes = date.Minute;

                    for (int i = fallAsleep; i < wakes; i++)
                    {
                        e.Asleep[i] = true;
                    }
                }

            }

            //don't forget to add the last event
            events.Add(e);

            return events;
        }


        public static Int64 GuardWithMostMinutesAsleep(List<Event> events)
        {
            var guardSleep = new Dictionary<Int64, Int64>();

            //determine how long each guard slept
            foreach (var e in events)
            {
                var minutesSleeping = e.Asleep.ToList().Where(x => x).Count();
                if (!guardSleep.ContainsKey(e.Id))
                {
                    guardSleep.Add(e.Id, minutesSleeping);
                }
                else
                {
                    guardSleep[e.Id] += minutesSleeping;
                }
            }

            //who slept the most?
            Int64 maxSleep = 0;
            Int64 foundKey = 0;
            foreach (var key in guardSleep.Keys)
            {
                if (guardSleep[key] > maxSleep)
                {
                    maxSleep = guardSleep[key];
                    foundKey = key;
                }
            }

            return foundKey;
        }

        public static Int64 WhichMinuteWasGuardAsleepTheMost(Int64 guardId, List<Event> events)
        {
            var minutes = new int[60];
            foreach(var e in events)
            {
                if (e.Id != guardId)
                {
                    continue;
                }

                for (int i=0; i < 60; i++)
                {
                    if (e.Asleep[i])
                    {
                        minutes[i]++;
                    }
                }
            }

            //which minute is most popular?
            var found = -1;
            var maxMins = 0;
            for(int m=0; m<60; m++)
            {
                if (minutes[m] > maxMins)
                {
                    maxMins = minutes[m];
                    found = m;
                }
            }

            return found;
        }

        public static Tuple<Int64, Int64> WhichGuardHasSleepiestMinute(List<Event> events)
        {
            var guardIds = events.Select(x => x.Id).Distinct();

            //item1 is the guard id, item 2 is the minute, item 3 is the count
            var guardSleepy = new List<Tuple<Int64, Int64, Int64>>();

            foreach (var guardId in guardIds)
            {
                var guardEvents = events.Where(x => x.Id == guardId);
                var minutes = new int[60];

                foreach (var guardEvent in guardEvents)
                {
                    for (int m = 0; m < 60; m++)
                    {
                        if (guardEvent.Asleep[m])
                        {
                            minutes[m]++;
                        }
                    }
                }

                int maxValue = minutes.Max();
                int maxIndex = minutes.ToList().IndexOf(maxValue);

                var sleepiestMinute = maxIndex;
                var count = maxValue;

                guardSleepy.Add(new Tuple<long, long, long>(guardId, sleepiestMinute, count));
            }

            //which guard was the sleepiest! which was the sleepiest minute?
            var maxCount = guardSleepy.Select(x => x.Item3).Max();
            var sleepiest = guardSleepy.Where(x => x.Item3 == maxCount).Single();

            //item1 is the sleepiest guard id, item 2 the sleepiest minute
            return new Tuple<Int64, Int64>(sleepiest.Item1, sleepiest.Item2);

        }
    
    }
}
