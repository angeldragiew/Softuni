using System;
using System.Linq;

namespace _03CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> minNumber = numbers =>
            {
                int minValue = int.MaxValue;
                foreach (var n in numbers)
                {
                    if (n < minValue)
                    {
                        minValue = n;
                    }
                }
                return minValue;
            };

            Console.WriteLine(minNumber(numbers));

        }
    }
}
