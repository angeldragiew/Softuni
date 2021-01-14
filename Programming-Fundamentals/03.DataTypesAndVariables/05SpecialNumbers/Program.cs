using System;

namespace _05SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            bool isSpecial = false;

            for (int i = 1; i <= n; i++)
            {
                int num = i;
                
                while (num != 0)
                {
                    int currentNum = 0;
                    currentNum = num % 10;
                    num /= 10;
                    sum += currentNum;

                    
                }
                isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine($"{i} -> {isSpecial}");
                sum = 0;
            }
        }
    }
}
