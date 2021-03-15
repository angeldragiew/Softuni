using System;
using System.Collections.Generic;
using System.Text;

namespace _02VehiclesExtension
{
    public abstract class Vehicle
    {
        private double fuelConsumptionIncrease;
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double fuelConsumptionIncrease)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.fuelConsumptionIncrease = fuelConsumptionIncrease;
        }

        public double TankCapacity { get; private  set; }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            protected set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; private set; }

        public virtual void Drive(double distance)
        {
            double neededFuel = distance * (FuelConsumption + fuelConsumptionIncrease);
            if (FuelQuantity - neededFuel < 0)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }
            FuelQuantity -= neededFuel;
        }
        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }
            if (fuelQuantity + fuel > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {fuel} fuel in the tank");
            }
            FuelQuantity += fuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
