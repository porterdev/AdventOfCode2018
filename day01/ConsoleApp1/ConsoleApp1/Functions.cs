using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Functions
    {
        public int FindFirstFrequencyReachedTwice(List<int> values)
        {
            var accumulator = 0;
            var index = 0;
            var loops = 0;

            var foundValues = new List<int>();

            while (loops < 1000000)
            {
                if (loops % 1000 == 0)
                {
                    Console.WriteLine("Loop {0} : Index {1} : Acc {2}", loops, index, accumulator);
                }
                
                if (foundValues.Contains(accumulator))
                {
                    break;
                }

                foundValues.Add(accumulator);

                accumulator += values[index];

                index++;
                if (index >= values.Count)
                {
                    index = 0;
                }

                loops++;
            }

            Console.WriteLine("loops: {0}", loops);

            return accumulator;
        }
    }
}
