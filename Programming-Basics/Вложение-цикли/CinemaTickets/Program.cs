using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            int freePlaces = int.Parse(Console.ReadLine());


            double totalTickets = 0;
            double totalStudentTickets = 0;
            double totalStandardTickets = 0;
            double totalKidTickets = 0;

            string ticket = "";

            double people = 0;
            while (movie != "Finish")
            {
               
                ticket = Console.ReadLine();
                while (ticket != "End")
                {
                   
                    totalTickets++;
                    people++;
                   


                    if (ticket == "student")
                    {
                        totalStudentTickets++;
                    }else if(ticket== "standard")
                    {
                        totalStandardTickets++;
                    }
                    else if (ticket == "kid")
                    {
                        totalKidTickets++;
                    }
                    if (freePlaces <= people)
                    {
                        break;
                    }
                    ticket = Console.ReadLine();

                  
                }
                
                Console.WriteLine($"{movie} - {(people /freePlaces)*100:f2}% full.");
                people = 0;
                movie = Console.ReadLine();
                if (movie == "Finish")
                {
                    break;
                }
                freePlaces = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{(totalStudentTickets/totalTickets)*100:f2}% student tickets.");
            Console.WriteLine($"{(totalStandardTickets/totalTickets)*100:f2}% standard tickets.");
            Console.WriteLine($"{(totalKidTickets/totalTickets)*100:f2}% kids tickets.");
        }
    }
}
