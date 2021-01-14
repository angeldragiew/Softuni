using System;

namespace _04PrintingTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintTriangle(number);
            //PrintingTriangle(number);
        }

        static void PrintLine(int end)
        {
            for (int i = 1; i <= end; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }

        static void PrintTriangle(int end)
        {
            for (int i = 1; i <= end; i++)
            {
                PrintLine(i);
            }

            for (int i = end - 1; i >= 1; i--)
            {
                PrintLine(i);
            }
        }

        //static void PrintingTriangle(int number)
        //{
        //    for (int i = 1; i <= number; i++)
        //    {
        //        for (int z = 1; z <= i; z++)
        //        {
        //            Console.Write($"{z} ");
        //        }
        //        Console.WriteLine();
        //    }

        //    for (int a = number - 1; a >= 1; a--)
        //    {
        //        for (int y = 1; y <= a; y++)
        //        {
        //            Console.Write($"{y} ");
        //        }
        //        Console.WriteLine();
        //    }
        //}
    }
}
