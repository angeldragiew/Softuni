using System;

namespace GreaterNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            if (a >= b)
            {
                Console.WriteLine(a);
            }
            else if(b>a)
            {
                Console.WriteLine(b);
            }
        }
    }
}
