using System;

namespace Aquapark
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int hours = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            string timeOfTheDay = Console.ReadLine();

            double priceForOnePerson = 0;

            if (timeOfTheDay == "day")
            {
                switch (month)
                {
                    case "march":
                    case "april":
                    case "may":
                        priceForOnePerson = 10.50;
                        break;
                    case "june":
                    case "july":
                    case "august":
                        priceForOnePerson = 12.60;
                        break;

                }
            }
            else
            {
                switch (month)
                {
                    case "march":
                    case "april":
                    case "may":
                        priceForOnePerson = 8.4;
                        break;
                    case "june":
                    case "july":
                    case "august":
                        priceForOnePerson = 10.20;
                        break;

                }
            }

            if (people >= 4)
            {
                priceForOnePerson *= 0.90;
            }

            if (hours>=5)
            {
                priceForOnePerson *= 0.50;
            }

            Console.WriteLine($"Price per person for one hour: {priceForOnePerson:f2}");
            Console.WriteLine($"Total cost of the visit: {priceForOnePerson*people*hours:f2}");
        }
    }
}
