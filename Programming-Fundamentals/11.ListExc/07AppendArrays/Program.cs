using System;
using System.Collections.Generic;
using System.Linq;

namespace _07AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> arrays = input.Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            arrays.Reverse();

            List<int> lastArray = new List<int>();

            for (int i = 0; i < arrays.Count; i++)
            {
                string[] s = arrays[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int z = 0; z < s.Length; z++)
                {
                    lastArray.Add(int.Parse(s[z]));
                }
            }

            Console.WriteLine(string.Join(" ", lastArray));
        }
    }
}
