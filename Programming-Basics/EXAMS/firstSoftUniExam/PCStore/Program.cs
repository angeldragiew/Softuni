using System;

namespace PCStore
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double processorPrice = double.Parse(Console.ReadLine());
            double videocardPrice = double.Parse(Console.ReadLine());
            double ramPlatePrice = double.Parse(Console.ReadLine());
            double ramPlateCount = double.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            processorPrice *= 1.57;
            videocardPrice *= 1.57;
            ramPlatePrice *= ramPlateCount;
            ramPlatePrice *= 1.57;

            processorPrice -= processorPrice * discount;
            videocardPrice -= videocardPrice * discount;

            double total = processorPrice + videocardPrice + ramPlatePrice;

            Console.WriteLine($"Money needed - {total:f2} leva.");

        }
    }
}
