using System;

namespace _10MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int evenSum = SumOfEvenDigits(num);
            int oddSum = SumOfOddDigits(num);

            int result = evenSum * oddSum;

            Console.WriteLine(result);

        }

        static int SumOfOddDigits(int number)
        {
            int sum = 0;
            int num = Math.Abs(number);
            int currNum = num;
            while (num > 0)
            {
                currNum = num % 10;
                num /= 10;
                if (currNum % 2 != 0)
                {
                    sum += currNum;
                }
            }

            return sum;
        }

        static int SumOfEvenDigits(int number)
        {
            int sum = 0;
            int num = Math.Abs(number);
            int currNum = num;
            while (num > 0)
            {
                currNum = num % 10;
                num /= 10;

                if (currNum % 2 == 0)
                {
                    sum += currNum;
                }
            }

            return sum;
        }
    }
}
