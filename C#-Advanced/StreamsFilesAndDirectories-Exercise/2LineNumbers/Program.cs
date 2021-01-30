using System;
using System.Collections.Generic;
using System.IO;

namespace _2LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] allLines = File.ReadAllLines("../../../input.txt");

            for (int i = 0; i < allLines.Length; i++)
            {
                int letters = 0;
                int punctuationMarksCount = 0;
                string currLine = allLines[i];
                foreach (var currChar in currLine)
                {
                    if (char.IsLetter(currChar))
                    {
                        letters++;
                    }
                    else if (char.IsPunctuation(currChar))
                    {
                        punctuationMarksCount++;
                    }
                }
                string changedLine = $"Line {i + 1}: {currLine} ({letters})({punctuationMarksCount})";
                allLines[i] = changedLine;
            }
            File.WriteAllLines("../../../output.txt", allLines);
        }
    }
}
