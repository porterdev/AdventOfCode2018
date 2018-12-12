using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public static class Functions
    {
        public static string Process(string input)
        {
            var list = input.ToCharArray().ToList();

            for (int i = 0; i < list.Count - 1; i++)
            {
                //difference between lower and upper case chars is 32
                if (Math.Abs(list[i] - list[i+1]) == 32)
                {
                    //remove from list
                    list.RemoveAt(i + 1);
                    list.RemoveAt(i);
                    //go back and start again
                    i = -1;
                }
                
            }

            return string.Concat(list);
        }

        public static string Remove(string input, char c)
        {
            var chars = input.Where(x => (x != c) && (x != (c - 32)));
            return string.Concat(chars);
        }

        public static string GetShortestPolymer(string input)
        {
            var shortest = string.Empty;
            for (char c='a'; c<='z'; c++)
            {
                var removedChar = Functions.Remove(input, c);
                var result = Functions.Process(removedChar);

                if (shortest.Length == 0 || result.Length < shortest.Length)
                {
                    shortest = result;
                }
            }

            return shortest;
        }
    }
}
