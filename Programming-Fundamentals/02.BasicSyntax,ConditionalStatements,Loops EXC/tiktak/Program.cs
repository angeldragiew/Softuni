using System;

namespace tiktak
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            for (int i = start; i <= end; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.Write("tik-tak ");
                }
                else if (i % 3 == 0)
                {
                    Console.Write("tik ");
                }
                else if (i % 5 == 0)
                {
                    Console.Write("tak ");
                }             
                else
                {
                    Console.Write($"{i} ");
                }
            }



        }
    }
}
