using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionFor1km = double.Parse(carInfo[2]);

                Car currCar = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars.Add(currCar);
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = input.Split();
                string carModel = cmdArgs[1];
                double amountOfKm = double.Parse(cmdArgs[2]);

                int carIndex = cars.FindIndex(c => c.Model == carModel);
                cars[carIndex].Drive(amountOfKm);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
