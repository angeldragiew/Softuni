using System;
using System.Linq;

namespace _04Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            arr = arr.OrderByDescending(x => x).ToArray();
            int n = 3;
            if (arr.Length < 3)
            {
                n = arr.Length;
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }
    }
}
