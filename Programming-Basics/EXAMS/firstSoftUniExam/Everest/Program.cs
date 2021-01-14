using System;

namespace Everest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string rest = Console.ReadLine();
            int metresToClimb = 0;
            
            int start = 5364;
            int goal = 8848;

            int days = 1;
           
            bool success = false;

            while (rest!="END")
            {
                metresToClimb = int.Parse(Console.ReadLine());

                days++;

                if (rest == "No")
                {
                    days--;
                }
                
                if (days > 5)
                {
                    break;
                }

                start += metresToClimb;

                if (start >= goal)
                {
                    success = true;
                    break;
                }

                
                rest = Console.ReadLine();
            }

            if (success)
            {
                Console.WriteLine($"Goal reached for {days} days!");
            }
            else
            {
                Console.WriteLine("Failed!");
                Console.WriteLine($"{start}");
            }
        }
    }
}
