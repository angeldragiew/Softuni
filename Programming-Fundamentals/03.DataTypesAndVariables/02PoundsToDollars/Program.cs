using System;

namespace _02PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal britishPound = decimal.Parse(Console.ReadLine());

            decimal usd = britishPound * 1.31M;

            Console.WriteLine($"{usd:F3}");
        }
    }
}
