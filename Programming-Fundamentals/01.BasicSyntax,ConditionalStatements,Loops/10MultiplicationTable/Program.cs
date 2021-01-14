using System;

namespace _10MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int multiplier = 1; multiplier <=10; multiplier++)
            {
                Console.WriteLine($"{n} X {multiplier} = {n*multiplier}");
            }
        }
    }
}
