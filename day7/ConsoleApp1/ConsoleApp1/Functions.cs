using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public static class Functions
    {
        public static Tuple<char,char> ParseRule(string input)
        {
            //Step B must be finished before step X can begin.
            Regex regex = new Regex("^Step ([A-Z]) must be finished before step ([A-Z]) can begin.$");
            Match match = regex.Match(input);
            var first = match.Groups[1].Value.First();
            var second = match.Groups[2].Value.First();

            return new Tuple<char, char>(first, second);

        }

        public static Dictionary<char, Rule> ProcessRules(List<string> inputs)
        {
            var rules = new Dictionary<char, Rule>();
            foreach (var input in inputs)
            {
                var rule = Functions.ParseRule(input);

                if (!rules.ContainsKey(rule.Item1))
                {
                    rules.Add(rule.Item1, new Rule());
                }

                if (!rules.ContainsKey(rule.Item2))
                {
                    rules.Add(rule.Item2, new Rule());
                }
                rules[rule.Item2].Requires.Add(rule.Item1);
            }

            return rules;
        }

        public static string DetermineExecutionOrder(Dictionary<char, Rule> rules)
        {
            var sb = new StringBuilder();

            //get rules that have no prerequisites
            while (rules.Count > 0)
            {
                var key = rules.Where(x => x.Value.Requires.Count == 0).Select(x => x.Key).OrderBy(x => x).First();

                sb.Append(key);

                rules.Remove(key);

                var successorKeys = rules.Where(x => x.Value.Requires.Contains(key)).Select(x => x.Key);

                foreach (var successorKey in successorKeys)
                {
                    rules[successorKey].Requires.Remove(key);
                }
            }

            return sb.ToString();

        }

    }
}
