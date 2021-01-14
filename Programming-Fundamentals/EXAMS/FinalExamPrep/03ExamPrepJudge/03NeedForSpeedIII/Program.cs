using System;
using System.Collections.Generic;
using System.Linq;

namespace _03NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, MileFuel> cars = new Dictionary<string, MileFuel>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string carName = carInfo[0];
                int mileage = int.Parse(carInfo[1]);
                int fuel = int.Parse(carInfo[2]);

                cars.Add(carName, new MileFuel { Mileage = mileage, Fuel = fuel });
            }

            string input;
            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = cmdArgs[0];

                if (command == "Drive")
                {
                    string carName = cmdArgs[1];
                    int distance = int.Parse(cmdArgs[2]);
                    int fuel = int.Parse(cmdArgs[3]);

                    if (cars[carName].Fuel - fuel < 0)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[carName].Mileage += distance;
                        cars[carName].Fuel -= fuel;
                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    if (cars[carName].Mileage >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {carName}!");
                        cars.Remove(carName);
                    }
                }
                else if (command == "Refuel")
                {
                    string carName = cmdArgs[1];
                    int fuel = int.Parse(cmdArgs[2]);

                    int refueledFuel = 0;

                    if (cars[carName].Fuel + fuel > 75)
                    {
                        refueledFuel = (cars[carName].Fuel + fuel) - 75;
                        cars[carName].Fuel = 75;
                    }
                    else
                    {
                        refueledFuel = fuel;
                        cars[carName].Fuel += fuel;
                    }
                    Console.WriteLine($"{carName} refueled with {refueledFuel} liters");
                }
                else if (command == "Revert")
                {
                    string carName = cmdArgs[1];
                    int kilometers = int.Parse(cmdArgs[2]);
                    cars[carName].Mileage -= kilometers;

                    if (cars[carName].Mileage < 10000)
                    {
                        cars[carName].Mileage = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                    }
                    

                   
                }
            }

            foreach (var car in cars.OrderByDescending(m=>m.Value.Mileage).ThenBy(n=>n.Key))
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }

        class MileFuel
        {
            public int Mileage { get; set; }
            public int Fuel { get; set; }
        }
    }
}
