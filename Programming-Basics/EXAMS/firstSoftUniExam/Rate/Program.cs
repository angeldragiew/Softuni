using System;

namespace Rate
{
    class Program
    {
        static void Main(string[] args)
        {
            double sum = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());

            double simpleInterestSum = sum;
            double complexInterestSum = sum;

            for (int i = 1; i <= months; i++)
            {
                simpleInterestSum += sum * 0.03;
            }

            for (int i = 1; i <= months; i++)
            {
                complexInterestSum += complexInterestSum * 0.027;
            }


            Console.WriteLine($"Simple interest rate: {simpleInterestSum:f2} lv.");
            Console.WriteLine($"Complex interest rate: {complexInterestSum:f2} lv.");

            if (simpleInterestSum > complexInterestSum)
            {
                Console.WriteLine($"Choose a simple interest rate. You will win {simpleInterestSum-complexInterestSum:f2} lv.");
            }
            else
            {
                Console.WriteLine($"Choose a complex interest rate. You will win {complexInterestSum-simpleInterestSum:f2} lv.");
            }
        }
    }
}
