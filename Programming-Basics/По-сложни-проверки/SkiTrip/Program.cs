using System;

namespace SkiTrip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string feedBack = Console.ReadLine();
            days--;
            double discount = 0;
            double price = 0;

            double roomForOnePerson = 18;
            double apartment = 25;
            double presidentApartment = 35;

            switch (room)
            {
                case "room for one person":
                    price = days * roomForOnePerson;
                    break;
                case "apartment":
                    if (days < 10)
                    {
                        discount = 70;
                        price = (days * apartment) * (discount / 100);
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        discount = 65;
                        price = (days * apartment) * (discount / 100);
                    }
                    else if (days > 15)
                    {
                        discount = 50;
                        price = (days * apartment) * (discount / 100);
                    }
                    break;
                case "president apartment":
                    if (days < 10)
                    {
                        discount = 90;
                        price = (days * presidentApartment) * (discount / 100);
                    }
                    else if (days >= 10 && days <= 15)
                    {
                        discount = 85;
                        price = (days * presidentApartment) * (discount / 100);
                    }
                    else if (days > 15)
                    {
                        discount = 80;
                        price = (days * presidentApartment) * (discount / 100);
                    }
                    break;
            }

            switch (feedBack)
            {
                case "positive":
                    price += price * .25;
                    break;
                case "negative":
                    price -= price * .10;
                    break;
            }

            Console.WriteLine($"{price:f2}");
        }
    }
}
