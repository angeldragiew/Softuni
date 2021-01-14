using System;

namespace _02MountainRun
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double recordInSeconds = double.Parse(Console.ReadLine());
            double recordInMeters = double.Parse(Console.ReadLine());
            double secsForMeter = double.Parse(Console.ReadLine());

            double delay = Math.Floor((recordInMeters / 50))*30;


            double georgeTime = recordInMeters * secsForMeter + delay;

            if (recordInSeconds > georgeTime)
            {
                Console.WriteLine($"Yes! The new record is {georgeTime:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No! He was {Math.Abs(recordInSeconds-georgeTime):f2} seconds slower.");
            }
        }
    }
}
