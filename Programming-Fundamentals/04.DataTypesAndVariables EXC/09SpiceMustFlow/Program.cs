using System;

namespace _09SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int totalSpice = 0;
            int days = 0;

            while (yield>=100)
            {
                days++;
                totalSpice += yield;
                if (totalSpice < 26)
                {
                    totalSpice = 0;
                }
                else
                {
                    totalSpice -= 26;
                }
                
                yield -= 10;
            }

            if (totalSpice < 26)
            {
                totalSpice = 0;
            }
            else
            {
                totalSpice -= 26;
            }

            Console.WriteLine(days);
            Console.WriteLine(totalSpice);
        }
    }
}
