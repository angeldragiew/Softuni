using System;
using System.Text.RegularExpressions;

namespace _06ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^|(?<=\s))([A-Za-z0-9]+)([_\-\.]*)([A-Za-z0-9]+)@([A-Za-z0-9]+([_\-\.][A-Za-z0-9]+)+)(\b|(?=\s))";
            string text = Console.ReadLine();

            var validEmails = Regex.Matches(text, pattern);

            foreach (var email in validEmails)
            {
                Console.WriteLine(email);
            }
        }
    }
}
