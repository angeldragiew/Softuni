using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string tiresInput;
            while ((tiresInput = Console.ReadLine()) != "No more tires")
            {
                string[] tiresInfo = tiresInput.Split();
                List<Tire> currTires = new List<Tire>();
                for (int i = 0; i < tiresInfo.Length; i += 2)
                {
                    int year = int.Parse(tiresInfo[i]);
                    double pressure = double.Parse(tiresInfo[i + 1]);
                    Tire currTire = new Tire(year, pressure);
                    currTires.Add(currTire);
                }
                tires.Add(currTires.ToArray());
            }

            string enginesInput;
            while ((enginesInput = Console.ReadLine()) != "Engines done")
            {
                string[] enginesInfo = enginesInput.Split();
                int horsePower = int.Parse(enginesInfo[0]);
                double cubicCapacity = double.Parse(enginesInfo[1]);

                Engine currEngine = new Engine(horsePower, cubicCapacity);
                engines.Add(currEngine);
            }

            string carsInput;
            while ((carsInput = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = carsInput.Split();
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tireIndex = int.Parse(carInfo[6]);

                Engine engine = engines[engineIndex];
                Tire[] currTire = tires[tireIndex];
                Car currCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, currTire);

                cars.Add(currCar);
            }

            foreach (var car in cars)
            {
                double tirePressureSum = 0;
                foreach (var tire in car.Tires)
                {
                    tirePressureSum += tire.Pressure;
                }
                bool isSpecial = car.Year >= 2017 && car.Engine.HorsePower >= 330 && tirePressureSum > 9 && tirePressureSum < 10;

                if (isSpecial)
                {
                    car.Drive(20);
                    Console.WriteLine($"Make: {car.Make}");

                    Console.WriteLine($"Model: {car.Model}");

                    Console.WriteLine($"Year: {car.Year}");

                    Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");

                    Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}
