using System;
using System.Linq;

namespace _05TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                bool isBigInt = true;
                for (int z = i+1; z < arr.Length; z++)
                {
                    if (arr[i] <= arr[z])
                    {
                        isBigInt = false;
                    }
                }
                if (isBigInt)
                {
                    Console.Write($"{arr[i]} ");
                }
            }
        }
    }
}
