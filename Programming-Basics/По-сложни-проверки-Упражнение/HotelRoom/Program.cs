using System;

namespace HotelRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studioDiscount = 0;
            double apartmentDiscount = 0;
            double apartmentPrice = 0;
            double studioPrice = 0;

            if(nights>7 && nights<=14 && month== "May" || nights > 7 && nights <= 14 && month == "October")
            {
                studioDiscount = 0.05;
            }else if(nights > 14 && month == "May" || nights > 14 && month == "October")
            {
                studioDiscount = 0.3;
            }
            else if(nights > 14 && month == "June" || nights > 14 && month == "September")
            {
                studioDiscount = 0.2;
            }
            
            if (nights > 14)
            {
                apartmentDiscount = 0.1;
            }

            switch (month)
            {
                case "May":
                case "October":
                    studioPrice = 50;
                    apartmentPrice = 65;
                    break;
                case "June":
                case "September":
                    studioPrice = 75.20;
                    apartmentPrice = 68.70;
                    break;
                case "July":
                case "August":
                    studioPrice = 76;
                    apartmentPrice = 77;
                    break;
            }

            if (studioDiscount != 0)
            {
                studioPrice = studioPrice - (studioPrice * studioDiscount);
            }

            if (apartmentDiscount != 0)
            {
                apartmentPrice = apartmentPrice - (apartmentPrice * apartmentDiscount);
            }

            Console.WriteLine($"Apartment: {apartmentPrice*nights:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice* nights:f2} lv.");
        }
    }
}
