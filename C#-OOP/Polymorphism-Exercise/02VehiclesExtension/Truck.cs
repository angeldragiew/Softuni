using System;
using System.Collections.Generic;
using System.Text;

namespace _02VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionIncrease = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, fuelConsumptionIncrease)
        {
        }

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }
            if (FuelQuantity + fuel > TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {fuel} fuel in the tank");
            }
            FuelQuantity += 0.95 * fuel;
        }
    }
}
