using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _03HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine()
                .Split("@", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input;
            int currentIndex = 0;
            while ((input = Console.ReadLine()) != "Love!")
            {
                string[] cmdArgs = input.Split();

                int jumpLength = int.Parse(cmdArgs[1]);

                currentIndex += jumpLength;

                if (currentIndex >= 0 && currentIndex < neighborhood.Count)
                {
                    if (neighborhood[currentIndex] == 0)
                    {
                        Console.WriteLine($"Place {currentIndex} already had Valentine's day.");
                    }
                    else
                    {
                        neighborhood[currentIndex] -= 2;
                        if (neighborhood[currentIndex] == 0)
                        {
                            Console.WriteLine($"Place {currentIndex} has Valentine's day.");
                        }
                    }
                }
                else if (currentIndex < 0 || currentIndex >= neighborhood.Count)
                {
                    currentIndex = 0;

                    if (neighborhood[currentIndex] == 0)
                    {
                        Console.WriteLine($"Place {currentIndex} already had Valentine's day.");
                    }
                    else
                    {
                        neighborhood[currentIndex] -= 2;
                        if (neighborhood[currentIndex] == 0)
                        {
                            Console.WriteLine($"Place {currentIndex} has Valentine's day.");
                        }
                    }
                }
               
            }
            Console.WriteLine($"Cupid's last position was {currentIndex}.");

            bool isMissionSuccessful = neighborhood.All(x => x == 0);

            if (isMissionSuccessful)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                int houseCount = 0;

                foreach (var item in neighborhood)
                {
                    if (item != 0)
                    {
                        houseCount++;
                    }
                }
                Console.WriteLine($"Cupid has failed {houseCount} places.");
            }
        }
    }
}
