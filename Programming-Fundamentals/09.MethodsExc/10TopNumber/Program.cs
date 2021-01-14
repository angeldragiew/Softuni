using System;

namespace _10TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                TopNumberCheck(i);
            }
        }

        static void TopNumberCheck(int num)
        {
            bool isSumDivisibleByEight = false;
            bool isOneOddDigit = false;

            int sumOfNumbers = 0;

            int number = num;
            while (number > 0)
            {
                int currNum = number % 10;
                number /= 10;
                sumOfNumbers += currNum;
                if (currNum % 2 != 0)
                {
                    isOneOddDigit = true;
                }
            }
            if (sumOfNumbers % 8 == 0)
            {
                isSumDivisibleByEight = true;
            }

            if (isOneOddDigit && isSumDivisibleByEight)
            {
                Console.WriteLine(num);
            }
        }
    }
}
