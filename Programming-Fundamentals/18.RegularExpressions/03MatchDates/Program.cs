using System;
using System.Text.RegularExpressions;
namespace _03MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<day>(?:[0-2][0-9])|(?:[3][01]))([-./])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";
            var regex = new Regex(pattern);

            string dates = Console.ReadLine();

            var validDates = regex.Matches(dates);

            foreach (Match date in validDates)
            {
                string day = date.Groups["day"].Value;
                string month = date.Groups["month"].Value;
                string year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
