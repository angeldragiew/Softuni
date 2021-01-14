using System;

namespace NumberPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            int current = 0;

            bool end = false;

            for (int rows = 1; rows <= n; rows++)
            {
                for (int cols = 1; cols <= rows; cols++)
                {
                    if (current >= n)
                    {
                        end = true;
                        break;
                    }
                    current++;
                    Console.Write(current+" ");
                }
                Console.WriteLine();
                if (end)
                {
                    break;
                }
            }
        }
    }
}
