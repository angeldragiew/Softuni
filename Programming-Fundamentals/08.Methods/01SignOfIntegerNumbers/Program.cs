using System;

namespace _01SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            SignOfIntegerNumber(int.Parse(Console.ReadLine()));
        }

        static void SignOfIntegerNumber(int n)
        {
            if(n > 0)
            {
                Console.WriteLine($"The number {n} is positive.");
            }else if(n == 0)
            {
                Console.WriteLine("The number 0 is zero.");
            }
            else
            {
                Console.WriteLine($"The number {n} is negative.");
            }
        }
    }
}
