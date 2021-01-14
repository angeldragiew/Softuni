using System;

namespace FishingBoat
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermans = int.Parse(Console.ReadLine());

            double boatRent = 0;

            switch (season)
            {
                case "Spring":
                    boatRent = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    boatRent = 4200;
                    break;
                case "Winter":
                    boatRent = 2600;
                    break;
            }

            if (fishermans <= 6)
            {
                boatRent *= 0.90;
            }
            else if (fishermans <= 11)
            {
                boatRent *= 0.85;
            }
            else
            {
                boatRent *= 0.75;
            }

            if(season!= "Autumn" && fishermans % 2 == 0)
            {
                boatRent *= 0.95;
            }

            if (budget >= boatRent)
            {
                Console.WriteLine($"Yes! You have {budget-boatRent:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {boatRent-budget:f2} leva.");
            }
        }
    }
}
