using System;
using System.Linq;

namespace _01RecursiveArraySum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int arrSum = Sum(arr, 0);
            Console.WriteLine(arrSum);
        }

        public static int Sum(int[] arr, int index)
        {
            if (index == arr.Length - 1)
            {
                return arr[index];
            }

            return arr[index] + Sum(arr, index + 1);
        }
    }
}
