using System;
using System.Collections.Generic;
using System.Text;

namespace _02VehiclesExtension
{
    public class Bus : Vehicle
    {
        private const double fuelConsumptionIncrease = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, fuelConsumptionIncrease)
        {
        }

        public void DriveEmpty(double distance)
        {
            double neededFuel = distance * FuelConsumption;
            if (FuelQuantity - neededFuel < 0)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }
            FuelQuantity -= neededFuel;
        }

    }
}
