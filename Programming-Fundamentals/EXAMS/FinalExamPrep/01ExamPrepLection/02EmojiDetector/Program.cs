using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string emojiPattern = @"([:]{2}|[*]{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string digitsPattern = @"[0-9]";

            Dictionary<string, int> emojis = new Dictionary<string, int>();

            string text = Console.ReadLine();

            int cooTthreshold = 1;
            MatchCollection digits = Regex.Matches(text, digitsPattern);

            foreach (Match digit in digits)
            {
                cooTthreshold *= int.Parse(digit.Value);
            }

            MatchCollection validEmojis = Regex.Matches(text, emojiPattern);

            foreach (Match validEmoji in validEmojis)
            {
                string emoji = validEmoji.Value;
                int coolnes = CalculateCoolnes(validEmoji.Groups["emoji"].Value);

                emojis.Add(emoji, coolnes);
            }

            Console.WriteLine($"Cool threshold: {cooTthreshold}");

            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");
            foreach (var emoji in emojis)
            {
                if (emoji.Value >= cooTthreshold)
                {
                    Console.WriteLine(emoji.Key);
                }
            }

        }

        public static int CalculateCoolnes(string emoji)
        {
            int coolnes= 0;
            foreach (char ch in emoji)
            {
                coolnes += ch;
            }

            return coolnes;
        }
    }
}
