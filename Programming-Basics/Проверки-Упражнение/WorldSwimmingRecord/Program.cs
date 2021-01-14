using System;

namespace WorldSwimmingRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double worldSwimmingRecordinSecs = double.Parse(Console.ReadLine());
            double worldSwimmingRecordinMeters = double.Parse(Console.ReadLine());
            double timeForMeter = double.Parse(Console.ReadLine());

            double time = worldSwimmingRecordinMeters * timeForMeter;
            double flowSlow = Math.Floor((worldSwimmingRecordinMeters / 15)) * 12.5;
            time += flowSlow;
            if (worldSwimmingRecordinSecs>time)
            {
                Console.WriteLine($" Yes, he succeeded! The new world record is {time:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {time-worldSwimmingRecordinSecs:f2} seconds slower.");
            }
        }
    }
}
