using System;

namespace NewHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());
            double price = 0;

            switch (flower)
            {
                case "Roses":
                    if (quantity > 80)
                    {
                        price = (quantity * 5) * 0.9;
                    }
                    else
                    {
                        price = quantity * 5;
                    }
                    break;
                case "Dahlias":
                    if (quantity > 90)
                    {
                        price = (quantity * 3.80) * 0.85;
                    }
                    else
                    {
                        price = quantity * 3.80;
                    }
                    break;
                case "Tulips":
                    if (quantity > 80)
                    {
                        price = (quantity * 2.80) * 0.85;
                    }
                    else
                    {
                        price = quantity * 2.80;
                    }
                    break;
                case "Narcissus":
                    if (quantity < 120)
                    {
                        price = quantity * 3 + (quantity*3*.15);
                        
                    }
                    else
                    {
                        price = quantity * 3;
                    }
                    break;
                case "Gladiolus":
                    if (quantity < 80)
                    {
                        price = quantity * 2.50 + (quantity * 2.50 * .2);
                    }
                    else
                    {
                        price = quantity * 2.50;
                    }
                    break;
            }

            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {quantity} {flower} and {budget-price:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {price-budget:f2} leva more.");
            }
        }
    }
}
