using System;

namespace FoodDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            double chicken = 10.35;
            double fish = 12.40;
            double vegan = 8.15;

            int chickenMeals = int.Parse(Console.ReadLine());
            int fishMeals = int.Parse(Console.ReadLine());
            int veganMeals = int.Parse(Console.ReadLine());

            double total = chickenMeals * chicken + fishMeals * fish + veganMeals * vegan;
            total *= 1.20;
            total += 2.50;
            Console.WriteLine($"Total: {total:f2}");
        }
    }
}
