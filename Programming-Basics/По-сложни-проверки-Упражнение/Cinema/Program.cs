using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            double income = 0;

            switch (type)
            {
                case "Premiere":
                    income = rows * cols * 12;
                    break;
                case "Normal":
                    income = rows * cols * 7.5;
                    break;
                case "Discount":
                    income = rows * cols * 5;
                    break;   
            }

            Console.WriteLine($"{income:f2}");
        }
    }
}
