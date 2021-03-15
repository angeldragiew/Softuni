using System;

namespace _02VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] carData = Console.ReadLine().Split();
            Car car = new Car(double.Parse(carData[1]), double.Parse(carData[2]));

            string[] truckData = Console.ReadLine().Split();
            Truck truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]));

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string vehicleName = data[1];

                Vehicle vehicle = car;
                if (vehicleName == "Truck")
                {
                    vehicle = truck;
                }

                string command = data[0];
                if (command == "Drive")
                {
                    double distance = double.Parse(data[2]);
                    vehicle.Drive(distance);
                }
                else if (command == "Refuel")
                {
                    double fuel = double.Parse(data[2]);
                    vehicle.Refuel(fuel);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
