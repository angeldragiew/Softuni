using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _02MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([@]|[#])(?<firstWord>[A-Za-z]{3,})\1{2}(?<secondWord>[A-Za-z]{3,})\1";
            Regex regex = new Regex(pattern);

            List<string> mirorWords = new List<string>();

            string text = Console.ReadLine();

            MatchCollection matches = regex.Matches(text);

            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
                foreach (Match match in matches)
                {
                    string firstWord = match.Groups["firstWord"].Value;
                    string secondWord = match.Groups["secondWord"].Value;

                    char[] reversed = secondWord.ToCharArray();
                    Array.Reverse(reversed);
                    string secondWordReversed = new string(reversed);

                    if(firstWord== secondWordReversed)
                    {
                        string miror = firstWord + " <=> " + secondWord;
                        mirorWords.Add(miror);
                    }
                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            if (mirorWords.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirorWords));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }


        }
    }
}
