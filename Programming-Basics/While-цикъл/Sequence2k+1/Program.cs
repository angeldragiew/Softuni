using System;

namespace Sequence2k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            int n = 1;

            while (n <= input)
            {
                Console.WriteLine(n);
                n = n * 2 + 1;
            }
        }
    }
}
