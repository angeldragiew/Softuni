using System;

namespace SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string input = Console.ReadLine();

            int primeNumbersSum = 0;
            int nonPrimeNumbersSum = 0;

            int devideCount = 0;

            while (input!= "stop")
            {
                int num = int.Parse(input);
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    goto Skip;
                }

                for (int i = 1; i <= num; i++)
                {
                    if (num % i == 0)
                    {
                        devideCount++;
                    }
                }

                if (devideCount == 2)
                {
                    primeNumbersSum += num;
                }
                else
                {
                    nonPrimeNumbersSum += num;
                }

                devideCount = 0;
                Skip:
                input = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {primeNumbersSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeNumbersSum}");
        }
    }
}
