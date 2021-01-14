using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstInput;
            Catalog catalog = new Catalog();

            while ((firstInput = Console.ReadLine()) != "End")
            {
                string[] vehicleAttributes = firstInput.Split().ToArray();

                string typeOfVehicle = vehicleAttributes[0];
                string model = vehicleAttributes[1];
                string color = vehicleAttributes[2];
                int horsepower = int.Parse(vehicleAttributes[3]);

                if (typeOfVehicle == "car")
                {
                    Car car = new Car(typeOfVehicle, model, color, horsepower);

                    catalog.CarList.Add(car);
                }
                else if (typeOfVehicle == "truck")
                {
                    Truck truck = new Truck(typeOfVehicle, model, color, horsepower);

                    catalog.Trucklist.Add(truck);
                }
            } //Adding Vehicles To Catalog

            string secondInput;

            while ((secondInput = Console.ReadLine()) != "Close the Catalogue")
            {
                string modelInfo = secondInput;

                bool isTruckModel = catalog.Trucklist.Select(x => x.Model).Contains(modelInfo);
                bool isCarModel = catalog.CarList.Select(x => x.Model).Contains(modelInfo);

                if (isCarModel)
                {
                    int index = catalog.CarList.FindIndex(a => a.Model.Contains(modelInfo));

                    catalog.CarList[index].PrintInfo();
                }

                if (isTruckModel)
                {
                    int index = catalog.Trucklist.FindIndex(a => a.Model.Contains(modelInfo));
                    catalog.Trucklist[index].PrintInfo();
                }
            }

            if (catalog.CarList.Count > 0)
            {
                catalog.PrintAverageCarHorsePower();

            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (catalog.Trucklist.Count > 0)
            {
                catalog.PrintAverageTruckHorsePower();

            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }


        }

        class Catalog
        {
            public Catalog()
            {
                CarList = new List<Car>();
                Trucklist = new List<Truck>();
            }
            public List<Car> CarList { get; set; }
            public List<Truck> Trucklist { get; set; }

            public void PrintAverageCarHorsePower()
            {
                double averageHp = 0;

                foreach (var car in CarList)
                {
                    averageHp += car.Horsepower;
                }

                averageHp /= CarList.Count;
                Console.WriteLine($"Cars have average horsepower of: {averageHp:f2}.");
            }

            public void PrintAverageTruckHorsePower()
            {
                double averageHp = 0;

                foreach (var truck in Trucklist)
                {
                    averageHp += truck.Horsepower;
                }

                averageHp /= Trucklist.Count;
                Console.WriteLine($"Trucks have average horsepower of: {averageHp:f2}.");
            }
        }

        class Car
        {
            public Car(string TypeOfVehicle, string Model, string Color, int Horsepower)
            {
                this.TypeOfVehicle = TypeOfVehicle;
                this.Model = Model;
                this.Color = Color;
                this.Horsepower = Horsepower;
            }
            public string TypeOfVehicle { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int Horsepower { get; set; }

            public void PrintInfo()
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Type: Car");
                sb.AppendLine($"Model: {Model}");
                sb.AppendLine($"Color: {Color}");
                sb.Append($"Horsepower: {Horsepower.ToString()}");

                Console.WriteLine(sb.ToString());
            }

        }

        class Truck
        {
            public Truck(string TypeOfVehicle, string Model, string Color, int Horsepower)
            {
                this.TypeOfVehicle = TypeOfVehicle;
                this.Model = Model;
                this.Color = Color;
                this.Horsepower = Horsepower;
            }
            public string TypeOfVehicle { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int Horsepower { get; set; }
            public void PrintInfo()
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Type: Truck");
                sb.AppendLine($"Model: {Model}");
                sb.AppendLine($"Color: {Color}");
                sb.Append($"Horsepower: {Horsepower.ToString()}");

                Console.WriteLine(sb.ToString());
            }

        }
    }
}

