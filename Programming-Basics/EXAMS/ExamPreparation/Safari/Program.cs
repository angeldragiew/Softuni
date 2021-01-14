using System;

namespace Safari
{
    class Program
    {
        static void Main(string[] args)
        {
            double fuelPrice = 2.10;
            double tourGuide = 100;
            double discount = 0;


            double budget = double.Parse(Console.ReadLine());
            double fuelLitres = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();

            if(day== "Saturday")
            {
                discount = 0.9;
            }else if (day == "Sunday")
            {
                discount = 0.8;
            }

            double neededMoney = fuelLitres * fuelPrice + tourGuide;
            neededMoney *= discount;

            if (neededMoney <= budget)
            {
                Console.WriteLine($"Safari time! Money left: {budget-neededMoney:f2} lv. ");
            }
            else
            {
                Console.WriteLine($"Not enough money! Money needed: {neededMoney-budget:f2} lv.");
            }
        }
    }
}
