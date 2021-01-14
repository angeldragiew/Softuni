﻿using System;

namespace SumSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());
            int totalTimeInSeconds = firstTime + secondTime + thirdTime;
            int minutes = totalTimeInSeconds / 60;
            int seconds = totalTimeInSeconds % 60;
            if (seconds >= 10)
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }

        }
    }
}
