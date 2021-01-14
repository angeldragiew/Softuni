using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Gauss__Trick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int half = list.Count / 2;

            for (int i = 0; i < half; i++)
            {
                list[i] += list[list.Count-1];
                list.Remove(list[list.Count - 1]);
            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
