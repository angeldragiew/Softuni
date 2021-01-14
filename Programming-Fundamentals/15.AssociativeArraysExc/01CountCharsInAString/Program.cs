using System;
using System.Collections.Generic;

namespace _01CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];

                if(currChar == ' ')
                {
                    continue;
                }

                if (dictionary.ContainsKey(currChar))
                {
                    dictionary[currChar] += 1;
                }
                else
                {
                    dictionary.Add(currChar, 1);
                }
            }

            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
                 
        }
    }
}
