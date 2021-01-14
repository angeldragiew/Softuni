using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            ;
            double num = double.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            string output = Console.ReadLine();
            if (input == "mm")
            {
                if (output == "cm")
                {
                    num /= 10;
                }else if(output == "m")
                {
                    num /= 1000;
                }
            }
            if (input == "cm")
            {
                if (output == "mm")
                {
                    num *= 10;
                }
                else if (output == "m")
                {
                    num /= 100;
                }
            }
            if (input == "m")
            {
                if (output == "mm")
                {
                    num *= 1000;
                }
                else if (output == "cm")
                {
                    num *= 100;
                }
            }
            Console.WriteLine($"{num:f3}");
        }
    }
}
