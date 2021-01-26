using System;
using System.Collections.Generic;
using System.Linq;

namespace _05CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> occurrences = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currSymbol = input[i];

                if (!occurrences.ContainsKey(currSymbol))
                {
                    occurrences.Add(currSymbol, 0);
                }
                occurrences[currSymbol]++;
            }

            foreach (var symbol in occurrences.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
