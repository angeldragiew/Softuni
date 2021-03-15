using System;
using System.Collections.Generic;
using System.Text;

namespace _02VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelConsumptionIncrease;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double fuelConsumptionIncrease)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.fuelConsumptionIncrease = fuelConsumptionIncrease;
        }
        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get; protected set; }

        public void Drive(double distance)
        {
            double neededFuel = distance * (FuelConsumption + fuelConsumptionIncrease);
            if (FuelQuantity - neededFuel >= 0)
            {
                FuelQuantity -= neededFuel;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
        public virtual void Refuel(double fuel)
        {
            FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
