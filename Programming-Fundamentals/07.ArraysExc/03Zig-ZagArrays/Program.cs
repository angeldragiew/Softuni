﻿using System;
using System.Linq;

namespace _03Zig_ZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr1 = new int[n];
            int[] arr2 = new int[n];

            for (int i = 0; i < arr1.Length; i++)
            {
                int[] twoNums = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToArray();
                if (i % 2 == 0)
                {
                    arr1[i] = twoNums[0];
                    arr2[i] = twoNums[1];
                }
                else
                {
                    arr1[i] = twoNums[1];
                    arr2[i] = twoNums[0];
                }
            }

            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
        }
    }
}
