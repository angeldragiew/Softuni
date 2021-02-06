using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int enginesNumber = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < enginesNumber; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);
                Engine currEngine = new Engine(model, power);
                currEngine.Displacement = -1;
                if (engineInfo.Length == 3)
                {
                    string data = engineInfo[2];
                    if (Char.IsLetter(data[0]))
                    {
                        string efficiency = data;
                        currEngine.Efficiency = efficiency;
                    }
                    else
                    {
                        int displacement = int.Parse(data);
                        currEngine.Displacement = displacement;
                    }
                }
                else if (engineInfo.Length == 4)
                {
                    int displacement = int.Parse(engineInfo[2]);
                    currEngine.Displacement = displacement;
                    string efficiency = engineInfo[3];
                    currEngine.Efficiency = efficiency;
                }

                engines.Add(currEngine);
            }

            int carsNumber = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < carsNumber; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];

                string engineModel = carInfo[1];
                Engine engine = engines.FirstOrDefault(e => e.Model == engineModel);

                Car currCar = new Car(model, engine);
                currCar.Weight = -1;
                if (carInfo.Length == 3)
                {
                    string data = carInfo[2];
                    if (Char.IsLetter(data[0]))
                    {
                        string color = carInfo[2];
                        currCar.Color = color;
                    }
                    else
                    {
                        int weight = int.Parse(data);
                        currCar.Weight = weight;
                    }
                }
                else if (carInfo.Length == 4)
                {
                    int weight = int.Parse(carInfo[2]);
                    currCar.Weight = weight;
                    string color = carInfo[3];
                    currCar.Color = color;

                }

                cars.Add(currCar);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
