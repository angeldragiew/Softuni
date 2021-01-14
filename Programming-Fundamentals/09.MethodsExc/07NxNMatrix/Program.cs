using System;

namespace _07NxNMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            NxNMatrix(num);
        }

        static void NxNMatrix(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                for (int z = 1; z <= num; z++)
                {
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
            }
        }
    }
}
