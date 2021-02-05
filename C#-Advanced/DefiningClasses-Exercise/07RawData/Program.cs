using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split();
                string model = carInfo[0];

                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                double firstTirePressure = double.Parse(carInfo[5]);
                int firstTireAge = int.Parse(carInfo[6]);
                Tire firstTire = new Tire(firstTireAge, firstTirePressure);
                double secondTirePressure = double.Parse(carInfo[7]);
                int secondTireAge = int.Parse(carInfo[8]);
                Tire secondTire = new Tire(secondTireAge, secondTirePressure);
                double thirdTirePressure = double.Parse(carInfo[9]);
                int thirdTireAge = int.Parse(carInfo[10]);
                Tire thirdTire = new Tire(thirdTireAge, thirdTirePressure);
                double fourthTirePressure = double.Parse(carInfo[11]);
                int fourthTireAge = int.Parse(carInfo[12]);
                Tire fourthTire = new Tire(fourthTireAge, fourthTirePressure);
                Tire[] tires = new Tire[4] { firstTire, secondTire, thirdTire, fourthTire };

                Car currCar = new Car(model, engine, cargo, tires);
                cars.Add(currCar);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flamable")
            {
                foreach (var car in cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
