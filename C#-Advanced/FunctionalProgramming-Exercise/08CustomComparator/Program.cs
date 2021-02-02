using System;
using System.Linq;

namespace _08CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Array.Sort(numbers, (int a, int b) =>
            {
                if (a % 2 != 0 && b % 2 == 0)
                {
                    return 1;
                }
                else if (a % 2 == 0 && b % 2 != 0)
                {
                    return -1;
                }
                return a.CompareTo(b);
                return 0;
            });

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
