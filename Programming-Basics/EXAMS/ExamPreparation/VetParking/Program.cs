using System;

namespace VetParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double dayTotal = 0;
            double total = 0;
            double pricePerHour = 0;

            for (int d = 1; d <= days; d++)
            {
                for (int h = 1; h <= hours; h++)
                {
                    if(d%2==0 && h % 2 != 0)
                    {
                        pricePerHour = 2.50;
                    }else if(d % 2 != 0 && h % 2 == 0)
                    {
                        pricePerHour = 1.25;
                    }
                    else
                    {
                        pricePerHour = 1;
                    }
                    dayTotal += pricePerHour;
                }
                total += dayTotal;
                
                Console.WriteLine($"Day: {d} - {dayTotal:f2} leva");
                dayTotal = 0;
            }
            Console.WriteLine($"Total: {total:f2} leva");
        }
    }
}
