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

        public static int DetermineExecutionTime(Dictionary<char, Rule> rules, int workerCount, int offset)
        {
            var workers = new List<Worker>();
            for (int i = 0; i < workerCount; i++)
            {
                workers.Add(new Worker());
            }
            var assignedTasks = new List<char>();

            var timeTaken = 0;

            //get rules that have no prerequisites
            while (rules.Count > 0)
            {
                // active workers should do their work
                var activeWorkers = workers.Where(x => x.TimeRemaining > 0).ToList();
                foreach (var activeWorker in activeWorkers)
                {
                    activeWorker.TimeRemaining--;

                    if (activeWorker.TimeRemaining == 0)
                    {
                        //task is complete!
                        rules.Remove(activeWorker.WorkingOn);

                        var successorKeys = rules.Where(x => x.Value.Requires.Contains(activeWorker.WorkingOn)).Select(x => x.Key);

                        foreach (var successorKey in successorKeys)
                        {
                            rules[successorKey].Requires.Remove(activeWorker.WorkingOn);
                        }
                    }
                }

                // if any workers are idle, assign them any available tasks
                var idleWorkers = workers.Where(x => x.TimeRemaining == 0).ToList();

                var key = rules.Where(x => !assignedTasks.Contains(x.Key) && x.Value.Requires.Count == 0).Select(x => x.Key).OrderBy(x => x).FirstOrDefault();

                while (key != 0 && idleWorkers.Any())
                {
                    idleWorkers[0].WorkingOn = key;
                    idleWorkers[0].TimeRemaining = offset + (key - 64);
                    assignedTasks.Add(key);

                    idleWorkers = workers.Where(x => x.TimeRemaining == 0).ToList();
                    key = rules.Where(x => !assignedTasks.Contains(x.Key) && x.Value.Requires.Count == 0).Select(x => x.Key).OrderBy(x => x).FirstOrDefault();
                }

                if (rules.Count == 0)
                {
                    //don't add a time tick on the last run!
                    break;
                }

                timeTaken++;
            }

            return timeTaken;

        }
    }
}
