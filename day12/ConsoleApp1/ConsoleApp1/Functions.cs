using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public static class Functions
    {
        public static Tuple<string, bool> ParseRule(string input)
        {
            /* These are written as LLCRR => N,
             * where L are pots to the left,
             * C is the current pot being considered,
             * R are the pots to the right,
             * and N is whether the current pot will have a plant in the next generation.
             */

            Regex regex = new Regex("^([\\.#]{5}) => ([\\.#])$");
            Match match = regex.Match(input);
            var first = match.Groups[1].Value;
            var second = match.Groups[2].Value;

            var rule = new Tuple<string, bool>(first, second == "#");

            return rule;
        }

        public static string ApplyRules(List<Tuple<string, bool>> rules, string state)
        {
            var newState = new string('.', state.Length);

            foreach(var rule in rules)
            {
                for(int i=2; i<state.Length-2; i++)
                {
                    var substring = state.Substring(i - 2, 5);
                    if (substring == rule.Item1)
                    {
                        char[] charArray = newState.ToCharArray();
                        charArray[i] = rule.Item2 ? '#': '.';
                        newState = new string(charArray);
                    }
                }
            }

            return newState;
        }

        public static string ApplyRulesForXIterations(List<Tuple<string, bool>> rules, string state, int iterations)
        {
            var result = state;
            for (int i=0; i<iterations; i++)
            {
                result = ApplyRules(rules, result);
            }

            return result;
        }

        public static int DetermineStateValue(string state, int initialIndex)
        {
            var value = 0;
            var index = initialIndex;
            foreach (var x in state)
            {
                if (x == '#')
                {
                    value += index;
                }
                index++;
            }

            return value;
        }
    }
}
