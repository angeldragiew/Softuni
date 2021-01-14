using System;

namespace _08FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            FactorialDivision(firstNum, secondNum);
        }

        static void FactorialDivision(int firstNum, int secondNum)
        {
            double firstNumFact = 1;
            for (int i = 1; i <= firstNum; i++)
            {
                firstNumFact *= i;
            }

            double secondNumFact = 1;
            for (int i = 1; i <= secondNum; i++)
            {
                secondNumFact *= i;
            }

            double result = firstNumFact / secondNumFact;

            Console.WriteLine($"{result:f2}");
        }
    }
}
