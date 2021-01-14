using System;

namespace _04TrekkingMania
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int groups = int.Parse(Console.ReadLine());
            int totalPeople = 0;

            double peopleInMusala = 0;
            double peopleInMonblan = 0;
            double peopleInKilimandjaro = 0;
            double peopleInK2 = 0;
            double peopleInEverest = 0;

            for (int i = 1; i <= groups; i++)
            {
                int peopleInGroup = int.Parse(Console.ReadLine());
                totalPeople += peopleInGroup;

                if (peopleInGroup <= 5)
                {
                    peopleInMusala += peopleInGroup;
                }
                else if (peopleInGroup <= 12)
                {
                    peopleInMonblan += peopleInGroup;
                }
                else if (peopleInGroup <= 25)
                {
                    peopleInKilimandjaro += peopleInGroup;
                }
                else if (peopleInGroup <= 40)
                {
                    peopleInK2 += peopleInGroup;
                }
                else
                {
                    peopleInEverest += peopleInGroup;
                }
            }

            double peopleInMusalaPercent = peopleInMusala / totalPeople*100;
            double peopleInMonblanPercent = peopleInMonblan / totalPeople * 100;
            double peopleInKilimandjaroPercent = peopleInKilimandjaro / totalPeople * 100;
            double peopleInK2Percent = peopleInK2 / totalPeople * 100;
            double peopleInEverestPercent = peopleInEverest / totalPeople * 100;

            Console.WriteLine($"{peopleInMusalaPercent:f2}%");
            Console.WriteLine($"{peopleInMonblanPercent:f2}%");
            Console.WriteLine($"{peopleInKilimandjaroPercent:f2}%");
            Console.WriteLine($"{peopleInK2Percent:f2}%");
            Console.WriteLine($"{peopleInEverestPercent:f2}%");
        }
    }
}
