using System;

namespace EqualSumsEvenOddPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int firstNum = int.Parse(Console.ReadLine());
            int secNum = int.Parse(Console.ReadLine());

            int evenSum = 0;
            int oddSum = 0;


            for (int i = firstNum; i <= secNum; i++)
            {
                string currentNum = i.ToString();
                for (int current = 0; current < currentNum.Length; current++)
                {
                    int numDigit = int.Parse(currentNum[current].ToString());

                    if (current % 2 == 0)
                    {
                        evenSum += numDigit;
                    }
                    else
                    {
                        oddSum += numDigit;
                    }
                }
                if (oddSum == evenSum)
                {
                    Console.Write(i+ " ");
                }
                evenSum = 0;
                oddSum = 0;
            }
        }
    }
}
