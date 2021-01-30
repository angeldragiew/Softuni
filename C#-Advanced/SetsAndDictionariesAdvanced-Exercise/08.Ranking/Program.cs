using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();

            string firstInput;
            while ((firstInput = Console.ReadLine()) != "end of contests")
            {
                string[] contestInfo = firstInput.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contest = contestInfo[0];
                string pass = contestInfo[1];
                //ToCheckIfAlreadyExist
                contests.Add(contest, pass);
            }
            Dictionary<string, Dictionary<string, int>> candidates = new Dictionary<string, Dictionary<string, int>>();
            string secInput;
            while ((secInput = Console.ReadLine()) != "end of submissions")
            {
                string[] submissionInfo = secInput.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = submissionInfo[0];
                string pass = submissionInfo[1];
                string username = submissionInfo[2];
                int points = int.Parse(submissionInfo[3]);

                if (contests.ContainsKey(contest) && contests[contest] == pass)
                {
                    if (!candidates.ContainsKey(username))
                    {
                        candidates.Add(username, new Dictionary<string, int>());
                    }

                    if (!candidates[username].ContainsKey(contest))
                    {
                        candidates[username].Add(contest, points);
                    }

                    if (candidates.ContainsKey(username) && candidates[username].ContainsKey(contest))
                    {
                        if (candidates[username][contest] < points)
                        {
                            candidates[username][contest] = points;
                        }
                    }
                }
            }

            int maxPoints = int.MinValue;
            string bestCandidate = string.Empty;
            foreach (var candidate in candidates)
            {
                int points = CalculatePoints(candidate.Value);
                if (points > maxPoints)
                {
                    maxPoints = points;
                    bestCandidate = candidate.Key;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var candidate in candidates.OrderBy(n => n.Key))
            {
                Console.WriteLine(candidate.Key);
                foreach (var contest in candidate.Value.OrderByDescending(p => p.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        private static int CalculatePoints(Dictionary<string, int> contestPoints)
        {
            int maxPoints = 0;
            foreach (var contest in contestPoints)
            {
                maxPoints += contest.Value;
            }

            return maxPoints;
        }
    }
}
