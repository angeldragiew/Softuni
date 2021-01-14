using System;
using System.Text.RegularExpressions;

namespace _02Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([*]|[@])([A-Z][a-z]{2,})\1: \[([A-Za-z])\]\|\[([A-Za-z])\]\|\[([A-Za-z])\]\|(?!\[)";
            Regex regex = new Regex(pattern);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();

                Match match = regex.Match(message);
                char ch = message[^1];
                if (match.Success && ch =='|')
                {
                    string msg = match.Groups["2"].Value;
                    char firstCh = char.Parse(match.Groups["3"].Value);
                    char secCh = char.Parse(match.Groups["4"].Value);
                    char thirdCh = char.Parse(match.Groups["5"].Value);

                    Console.WriteLine($"{msg}: {(int)firstCh} {(int)secCh} {(int)thirdCh}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
