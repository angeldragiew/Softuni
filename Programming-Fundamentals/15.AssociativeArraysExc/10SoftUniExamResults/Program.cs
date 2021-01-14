using System;
using System.Collections.Generic;
using System.Linq;

namespace _10SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            Dictionary<string, int> grades = new Dictionary<string, int>();
            Dictionary<string, int> languages = new Dictionary<string, int>();


            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] cmdArgs = input.Split("-").ToArray();
                string username = cmdArgs[0];
                if (cmdArgs.Length == 3)
                {                    
                    string language = cmdArgs[1];
                    int points = int.Parse(cmdArgs[2]);

                    if (grades.ContainsKey(username) == false)
                    {
                        grades.Add(username, 0);
                    }
                    if (grades[username] < points)
                    {
                        grades[username] = points;
                    }

                    if (languages.ContainsKey(language) == false)
                    {
                        languages.Add(language, 0);
                    }
                    languages[language]++;
                }
                else
                {
                    if (grades.ContainsKey(username))
                    {
                        grades.Remove(username);
                    }
                }
            }

            Console.WriteLine("Results:");
            foreach (var user in grades.OrderByDescending(x=>x.Value).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{ user.Key} | {user.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var language in languages.OrderByDescending(x=>x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
