using System;
using System.Xml.XPath;

namespace _08MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            double result = MathPower(number, power);
            Console.WriteLine(result);
        }

        static double MathPower(double num, int pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++)
            {
                result *=num;
            }
            return result;
        }
    }
}
