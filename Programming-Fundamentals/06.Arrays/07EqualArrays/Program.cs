using System;
using System.Linq;

namespace _07EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] secondArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int indexDiff = 0;

            bool isEqual = true;

            for (int i = 0; i < firstArr.Length; i++)
            {
                if (firstArr[i] == secondArr[i])
                {
                    continue;
                }
                else
                {
                    isEqual = false;
                    indexDiff = i;
                    break;
                }
            }

            if (isEqual)
            {
                int sum = 0;
                for (int i = 0; i < firstArr.Length; i++)
                {
                   sum += firstArr[i];
                }
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {indexDiff} index");
            }
        }
    }
}
