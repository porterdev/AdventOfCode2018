using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Functions
    {
        public bool ExactlyCount(string s, int count)
        {
            var dict = new Dictionary<char, int>();
            //if string contains any letters that occur exactly twice, return true, else false
            foreach (char c in s)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c]++;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            foreach (var key in dict.Keys)
            {
                if (dict[key] == count)
                {
                    return true;
                }
            }

            return false;

        }

        public int GetCheckSum(List<string> strings)
        {
            var twiceCount = 0;
            var thriceCount = 0;
            foreach (var s in strings)
            {
                if (ExactlyCount(s, 2))
                {
                    twiceCount++;
                }

                if (ExactlyCount(s, 3))
                {
                    thriceCount++;
                }
            }

            return twiceCount * thriceCount;
        }

        public int CompareStrings(string first, string second)
        {
            //this function will return the number of characters different between two strings
            var counter = 0;
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    counter++;
                }
            }

            return counter;
        }

        public List<string> FindTwoCorrectBoxes(List<string> strings)
        {
            foreach (var x in strings)
            {
                foreach (var y in strings)
                {
                    var result = CompareStrings(x, y);

                    if (result == 1)
                    {
                        var correct = new List<string> { x, y };
                        Console.WriteLine("Correct boxes: {0}, {1}", x, y);
                        return correct;
                    }
                }
            }

            Console.WriteLine("Correct boxes not found!");
            return null;
        }

        public string FindCommonCharacters(string first, string second)
        {
            //this function will return the common characters between two strings
            var chars = new List<char>();
            for (int i = 0; i < first.Length; i++)
            {
                if (first[i] == second[i])
                {
                    chars.Add(first[i]);
                }
            }

            var sb = new StringBuilder();
            foreach (var c in chars)
            {
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}
