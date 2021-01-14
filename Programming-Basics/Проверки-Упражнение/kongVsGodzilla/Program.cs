using System;

namespace kongVsGodzilla
{
    class Program
    {
        static void Main(string[] args)
        {
            double movieBudget = double.Parse(Console.ReadLine());
            int supers = int.Parse(Console.ReadLine());
            double supersClothPrice = double.Parse(Console.ReadLine());
            double moneyForClothes = 0;
            double moneyForDecoration = movieBudget * 0.1;
            if (supers > 150)
            {
                moneyForClothes = (supers * supersClothPrice) * 0.9;
            }
            else
            {
                moneyForClothes = supers * supersClothPrice;
            }
            double neededMoney = moneyForDecoration + moneyForClothes;
            if (neededMoney > movieBudget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {neededMoney- movieBudget:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {movieBudget-neededMoney:f2} leva left.");
            }
        }
    }
}
