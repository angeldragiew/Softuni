using System;

namespace _02VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle car = CreateVehicle();
            Vehicle truck = CreateVehicle();
            Vehicle bus = CreateVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string vehicleName = data[1];

                Vehicle vehicle = car;
                if (vehicleName == nameof(Truck))
                {
                    vehicle = truck;
                }
                else if (vehicleName == nameof(Bus))
                {
                    vehicle = bus;
                }

                string command = data[0];
                if (command == "Drive")
                {
                    double distance = double.Parse(data[2]);
                    try
                    {
                        vehicle.Drive(distance);
                        Console.WriteLine($"{vehicle.GetType().Name} travelled {distance} km");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "Refuel")
                {
                    double fuel = double.Parse(data[2]);
                    try
                    {
                        vehicle.Refuel(fuel);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "DriveEmpty")
                {
                    double distance = double.Parse(data[2]);
                    try
                    {
                        ((Bus)vehicle).DriveEmpty(distance);
                        Console.WriteLine($"{vehicle.GetType().Name} travelled {distance} km");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static Vehicle CreateVehicle()
        {
            string[] data = Console.ReadLine().Split();
            double fuelQuantity = double.Parse(data[1]);
            double fuelConsumption = double.Parse(data[2]);
            double tankCapacity = double.Parse(data[3]);

            string type = data[0];
            Vehicle vehicle = null;
            if (type == nameof(Car))
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == nameof(Truck))
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == nameof(Bus))
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }

            return vehicle;
        }
    }
}
