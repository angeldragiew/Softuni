using System;
using System.Collections.Generic;
using System.Linq;

namespace _02OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split()
                .ToArray();

            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (dictionary.ContainsKey(arr[i].ToLower()))
                {
                    dictionary[arr[i].ToLower()] += 1;
                }
                else
                {
                    dictionary.Add(arr[i].ToLower(), 1);
                }
            }

            dictionary = dictionary.Where(p => p.Value % 2 != 0).ToDictionary(v => v.Key, v => v.Value);

            foreach (KeyValuePair<string,int> item in dictionary)
            {
                    Console.Write(item.Key + " ");
            }
        }
    }
}
