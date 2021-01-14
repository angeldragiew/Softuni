using System;

namespace _03Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleNumber = int.Parse(Console.ReadLine());
            string peopleType = Console.ReadLine();
            string day = Console.ReadLine();

            double pricePerPerson = 0;

            if(peopleType== "Students")
            {
                switch (day)
                {
                    case "Friday":
                        pricePerPerson = 8.45;
                        break;
                    case "Saturday":
                        pricePerPerson = 9.80;
                        break;
                    case "Sunday":
                        pricePerPerson = 10.46;
                        break;
                }
            }
            else if(peopleType== "Business")
            {
                switch (day)
                {
                    case "Friday":
                        pricePerPerson = 10.90;
                        break;
                    case "Saturday":
                        pricePerPerson = 15.60;
                        break;
                    case "Sunday":
                        pricePerPerson = 16;
                        break;
                }
            }
            else if (peopleType == "Regular")
            {
                switch (day)
                {
                    case "Friday":
                        pricePerPerson = 15;
                        break;
                    case "Saturday":
                        pricePerPerson = 20;
                        break;
                    case "Sunday":
                        pricePerPerson = 22.50;
                        break;
                }
            }

            double totalPrice = pricePerPerson * peopleNumber;

            if(peopleType=="Students" && peopleNumber >= 30)
            {
                totalPrice *= 0.85;
            }
            if (peopleType == "Business" && peopleNumber >= 100)
            {
                totalPrice -= 10 * pricePerPerson;
            }
            if (peopleType == "Regular" && peopleNumber >= 10 && peopleNumber<=20)
            {
                totalPrice *= 0.95;
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
