using System;
using System.Collections.Generic;

namespace _8TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCarsToPass = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();

            int carPassedCount = 0;

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < numberOfCarsToPass; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        carPassedCount++;
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }
            }

            Console.WriteLine($"{carPassedCount} cars passed the crossroads.");
        }
    }
}
