using System;

namespace _06CalculateRectangleArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int area = CalcRectangularArea(a, b);
            Console.WriteLine(area);
        }

        static int CalcRectangularArea(int a, int b)
        {
            int area = a*b;
            return area;
        }
    }
}
