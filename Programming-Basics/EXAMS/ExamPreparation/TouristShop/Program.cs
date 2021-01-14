using System;

namespace TouristShop
{
    class Program
    {
        static void Main(string[] args)
        {
            ;
            float budget = float.Parse(Console.ReadLine());
            float price = 0;

            int count = 0;
            bool enoughMoney = true;
            string item = Console.ReadLine();
            float total = 0;
            while (item!="Stop")
            {
                price = float.Parse(Console.ReadLine());
                count++;
                if (count % 3 == 0)
                {
                    price /= 2;
                }
                budget -= price;
                if (budget < 0)
                {
                    enoughMoney = false;
                    break;
                }
                total += price;
                
                item = Console.ReadLine();
            }

            if (enoughMoney)
            {
                Console.WriteLine($"You bought {count} products for {total:f2} leva.");
            }
            else
            {
                Console.WriteLine("You don't have enough money!");
                Console.WriteLine($"You need {Math.Abs(budget):f2} leva!");
            }
        }
    }
}
