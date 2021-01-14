using System;

namespace _05Orders
{
    class Program
    {
        static double coffeePrice = 1.50;
        static double waterPrice = 1.00;
        static double cokePrice = 1.40;
        static double snacksPrice = 2.00;
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            Order(product, quantity);
        }

        static void Order(string product, int quantity)
        {
            double price = 0;
            switch (product)
            {
                case "coffee":
                    price = coffeePrice * quantity;
                    break;
                case "water":
                    price = waterPrice * quantity;
                    break;
                case "coke":
                    price = cokePrice * quantity;
                    break;
                case "snacks":
                    price = snacksPrice * quantity;
                    break;
            }

            Console.WriteLine($"{price:f2}");
        }
    }
}
