using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' ,'-', '?', '!', '\n', '\r'};
            Dictionary<string, int> words = new Dictionary<string, int>();
            using (StreamReader reader = new StreamReader("../../../words.txt"))
            {
                string[] wordsInput = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < wordsInput.Length; i++)
                {
                    words.Add(wordsInput[i], 0);
                }
            }

            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                string[] textWords = reader.ReadToEnd().Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < textWords.Length; i++)
                {
                    if (words.ContainsKey(textWords[i].ToLower()))
                    {
                        words[textWords[i].ToLower()]++;
                    }
                }
            }

            using(StreamWriter writer =  new StreamWriter("../../../output.txt"))
            {
                foreach (var word in words.OrderByDescending(x=>x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
