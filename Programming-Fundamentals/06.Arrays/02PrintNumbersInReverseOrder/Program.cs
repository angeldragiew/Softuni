using System;
using System.Linq;

namespace _02PrintNumbersInReverseOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            Console.Write(string.Join(", ", arr.Reverse()));

            //for (int i = arr.Length - 1; i >= 0; i--)
            //{
            //    Console.Write($"{arr[i]} ");
            //}
        }
    }
}
