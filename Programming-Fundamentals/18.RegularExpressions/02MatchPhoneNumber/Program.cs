using System;
using System.Text.RegularExpressions;

namespace _02MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+\b([359]+)((?:\-)|(?: ))2\2(\d{3})\2(\d{4})\b";

            var regex = new Regex(pattern);

            string numbers = Console.ReadLine();

            var validNumbers = regex.Matches(numbers);

            Console.WriteLine(string.Join(", ", validNumbers));
        }
    }
}
