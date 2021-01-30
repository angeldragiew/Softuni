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
            string[] wordsInput = File.ReadAllLines("../../../words.txt");
            Dictionary<string, int> words = new Dictionary<string, int>();

            foreach (var word in wordsInput)
            {
                words.Add(word.ToLower(), 0);
            }

            char[] delimiterChars = { ' ', ',', '.', ':', '\t', '-', '?', '!', '\n', '\r' };
            string[] allLines = File.ReadAllLines("../../../text.txt");

            foreach (var line in allLines)
            {
                string[] splittedLine = line.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in splittedLine)
                {
                    if (words.ContainsKey(word.ToLower()))
                    {
                        words[word.ToLower()]++;
                    }
                }
            }

            List<string> actualResult = new List<string>();
            foreach (var word in words)
            {
                actualResult.Add($"{word.Key} - {word.Value}");
            }

            List<string> expectedResult = new List<string>();
            foreach (var word in words.OrderByDescending(w=>w.Value))
            {
                expectedResult.Add($"{word.Key} - {word.Value}");
            }

            File.WriteAllLines("../../../actualResult.txt", actualResult);
            File.WriteAllLines("../../../expectedResult.txt", expectedResult);

            bool isEqual = File.ReadAllBytes("../../../expectedResult.txt").SequenceEqual(File.ReadAllBytes("../../../actualResult.txt"));
            if (isEqual)
            {
                Console.WriteLine("The files are equal");
            }else
            {
                Console.WriteLine("The files are NOT equal");
            }
        }
    }
}
