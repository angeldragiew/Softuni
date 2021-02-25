using System;

namespace _02RecursiveFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Fact(n));
        }

        public static int Fact(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Fact(n - 1);
        }
    }
}
