using System;

namespace _01SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int smallestNumber = SmallestOfThreeNumbers(firstNum, secondNum, thirdNum);
            Console.WriteLine(smallestNumber);
        }

        static int SmallestOfThreeNumbers(int firstNum, int secondNum, int thirdNum)
        {
            int[] arr = { firstNum, secondNum, thirdNum };
            int smallestNumber = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < smallestNumber)
                {
                    smallestNumber = arr[i];
                }
            }

            return smallestNumber;
        }

    }
}
