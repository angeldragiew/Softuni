using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02DestinationMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([=]|[\/])(?<destination>[A-Z][A-Za-z]{2,})\1";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, pattern);

            int travelPoints = 0;

            List<string> destionations = new List<string>();

            foreach (Match item in matches)
            {
                string name = item.Groups["destination"].Value;
                destionations.Add(name);
                travelPoints += name.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destionations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
