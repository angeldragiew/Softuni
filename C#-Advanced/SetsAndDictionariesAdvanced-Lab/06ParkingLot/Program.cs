using System;
using System.Collections.Generic;

namespace _06ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split(", ");
                string command = cmdArgs[0];
                string carNumber = cmdArgs[1];

                if (command == "IN")
                {
                    parking.Add(carNumber);
                }
                else
                {
                    parking.Remove(carNumber);
                }
            }

            if (parking.Count > 0)
            {
                foreach (var carNumber in parking)
                {
                    Console.WriteLine(carNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
