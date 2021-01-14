using System;

namespace AreaOfFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            double area;
            string figure = Console.ReadLine();
            switch(figure)
            {
                case "square":
                    double a = double.Parse(Console.ReadLine());
                    area = Math.Pow(a, 2);
                    Console.WriteLine($"{area:f3}");
                    break;

                case "rectangle":
                    double a1 = double.Parse(Console.ReadLine());
                    double b = double.Parse(Console.ReadLine());
                    area = a1 * b;
                    Console.WriteLine($"{area:f3}");
                    break;
                case "circle":
                    double r = double.Parse(Console.ReadLine());
                    area = Math.PI * Math.Pow(r, 2);
                    Console.WriteLine($"{area:f3}");
                    break;
                case "triangle":
                    double b1 = double.Parse(Console.ReadLine());
                    double hb = double.Parse(Console.ReadLine());
                    area = (b1 * hb) / 2;
                    Console.WriteLine($"{area:f3}");
                    break;
            }

            //if (figure == "square")
            //{
            //    double a = double.Parse(Console.ReadLine());
            //    area = Math.Pow(a, 2);
            //    Console.WriteLine($"{area:f3}");
            //}
            //else if (figure == "rectangle")
            //{
            //    double a = double.Parse(Console.ReadLine());
            //    double b = double.Parse(Console.ReadLine());
            //    area = a * b;
            //    Console.WriteLine($"{area:f3}");
            //}
            //else if (figure == "circle")
            //{
            //    double r = double.Parse(Console.ReadLine());
            //    area = Math.PI * Math.Pow(r, 2);
            //    Console.WriteLine($"{area:f3}");
            //}
            //else if (figure == "triangle")
            //{
            //    double b = double.Parse(Console.ReadLine());
            //    double hb = double.Parse(Console.ReadLine());
            //    area = (b * hb) / 2;
            //    Console.WriteLine($"{area:f3}");
            //}
        }
    }
}
