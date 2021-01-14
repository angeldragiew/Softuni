using System;
using System.Collections.Generic;
using System.Linq;

namespace _08VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            Catalog catalog = new Catalog();
            while ((input = Console.ReadLine()) != "end")
            {
                string[] arr = input.Split("/").ToArray();

                string type = arr[0];

                if(type == "Car")
                {
                    Car car = new Car();

                    car.Brand = arr[1];
                    car.Model = arr[2];
                    car.HorsePower = int.Parse(arr[3]);

                    catalog.CarList.Add(car);
                }
                else
                {
                    Truck truck = new Truck();

                    truck.Brand = arr[1];
                    truck.Model = arr[2];
                    truck.Weight = int.Parse(arr[3]);

                    catalog.TruckList.Add(truck);
                }
            }



            if (catalog.CarList.Count > 0)
            {
                List<Car> sortedCars = catalog.CarList.OrderBy(o => o.Brand).ToList();


                Console.WriteLine("Cars:");
                foreach (var car in sortedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalog.TruckList.Count > 0)
            {
                List<Truck> sortedTrucks = catalog.TruckList.OrderBy(o => o.Brand).ToList();

                Console.WriteLine("Trucks:");
                foreach (var truck in sortedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
            

        }

        class Catalog
        {
            public Catalog()
            {
                CarList = new List<Car>();
                TruckList = new List<Truck>();

            }

            public List<Car>  CarList{get; set; }
            
            public List<Truck>  TruckList{get; set; }
        }

        class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }
        }

        class Truck
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }
        }
    }
}
