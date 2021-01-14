using System;

namespace _07Theatre_Promotion
{
    class Program
    {
        static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int ticketPrice = 0;

            if(age>=0 && age <= 18)
            {
                switch (day)
                {
                    case "Weekday":
                        ticketPrice = 12;
                        break;
                    case "Weekend":
                        ticketPrice = 15;
                        break;
                    case "Holiday":
                        ticketPrice = 5;
                        break;
                }
                Console.WriteLine($"{ticketPrice}$");
            }
            else if(age>18 && age<=64)
            {
                switch (day)
                {
                    case "Weekday":
                        ticketPrice = 18;
                        break;
                    case "Weekend":
                        ticketPrice = 20;
                        break;
                    case "Holiday":
                        ticketPrice = 12;
                        break;
                }
                Console.WriteLine($"{ticketPrice}$");
            }
            else if (age > 64 && age <= 122)
            {
                switch (day)
                {
                    case "Weekday":
                        ticketPrice = 12;
                        break;
                    case "Weekend":
                        ticketPrice = 15;
                        break;
                    case "Holiday":
                        ticketPrice = 10;
                        break;
                }
                Console.WriteLine($"{ticketPrice}$");
            }
            else
            {
                Console.WriteLine("Error!");
            }

            
        }
    }
}
