using System;
using System.Drawing;

namespace _01NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());

            int people = int.Parse(Console.ReadLine());
            int hours = 0;
            while (people>0)
            {
                hours++;
                if (hours % 4 == 0)
                {
                    continue;
                }

                people -= firstEmployeeEfficiency;
                people -= secondEmployeeEfficiency;
                people -= thirdEmployeeEfficiency;
            }
            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
