using System;

namespace _01ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal meters = decimal.Parse(Console.ReadLine());

            decimal kilometers = meters / 1000M;

            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
