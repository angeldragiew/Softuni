using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double averageSuccess = double.Parse(Console.ReadLine());
            double minSalaray = double.Parse(Console.ReadLine());
            double socialScholarship = 0;
            double excellentScholarship = 0;

            if (income < minSalaray && averageSuccess >= 5.50)
            {
                socialScholarship = minSalaray * 0.35;
                excellentScholarship = averageSuccess * 25;

                if(socialScholarship > excellentScholarship)
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
                }else if(socialScholarship == excellentScholarship)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentScholarship)} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentScholarship)} BGN");
                }
            }
            else if(income<minSalaray && averageSuccess >= 4.50)
            {
                socialScholarship = minSalaray * 0.35;
                Console.WriteLine($"You get a Social scholarship {Math.Floor(socialScholarship)} BGN");
            }else if (averageSuccess >= 5.50)
            {
                excellentScholarship = averageSuccess * 25;
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(excellentScholarship)} BGN");
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
        }
    }
}
