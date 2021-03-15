using System;
using System.Collections.Generic;
using System.Text;

namespace _02VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double fuelConsumptionIncrease = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption, fuelConsumptionIncrease)
        {
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * 0.95);
        }
    }
}
