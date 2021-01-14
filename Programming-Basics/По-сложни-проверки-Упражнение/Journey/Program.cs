using System;

namespace Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string placeForSleeping = "";
            string destination = "";
            double moneyNeeded = 0;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                switch (season)
                {
                    case "summer":
                        placeForSleeping = "Camp";
                        moneyNeeded = budget *0.3;
                        break;
                    case "winter":
                        placeForSleeping = "Hotel";
                        moneyNeeded = budget * 0.7;
                        break;
                }
            }else if (budget <= 1000)
            {
                destination = "Balkans";
                switch (season)
                {
                    case "summer":
                        placeForSleeping = "Camp";
                        moneyNeeded = budget * 0.4;
                        break;
                    case "winter":
                        placeForSleeping = "Hotel";
                        moneyNeeded = budget * 0.8;
                        break;
                }
            }
            else
            {
                destination = "Europe";
                moneyNeeded = budget * 0.9;
                placeForSleeping = "Hotel";
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{placeForSleeping} - {moneyNeeded:f2}");
        }
    }
}
