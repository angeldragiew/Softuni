using System;

namespace Travelling
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string destination = Console.ReadLine();
            double destinationPrice = 0;
            double sum = 0;
            while (destination!= "End")
            {
                destinationPrice = double.Parse(Console.ReadLine());
                while (sum<destinationPrice)
                {
                    double saving = double.Parse(Console.ReadLine());
                    sum += saving;
                }
                sum = 0;
                Console.WriteLine($"Going to {destination}!");
                destination = Console.ReadLine();
                
            }
        }
    }
}
