using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => components.ToList();

        public IReadOnlyCollection<IPeripheral> Peripherals => peripherals.ToList();

        public override double OverallPerformance
        {
            get
            {
                if (components.Any() == false)
                {
                    return base.OverallPerformance;
                }
                return base.OverallPerformance + components.Average(c => c.OverallPerformance);
            }
        }

        public override decimal Price
        {
            get
            {
                return base.Price + components.Sum(c => c.Price) + peripherals.Sum(p => p.Price);
            }
        }

        public void AddComponent(IComponent component)
        {
            if(components.Any(c=>c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent,component.GetType().Name,this.GetType().Name, this.Id));
            }
            components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if(peripherals.Any(p=>p.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral,peripheral.GetType().Name, this.GetType().Name, this.Id));
            }
            peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if(components.Any(c => c.GetType().Name == componentType) == false)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent, componentType,this.GetType().Name, this.Id));
            }
            IComponent componetToRemove = components.First(c => c.GetType().Name == componentType);
            components.Remove(componetToRemove);
            return componetToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if(peripherals.Any(p=>p.GetType().Name == peripheralType) == false)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType,this.GetType().Name, this.Id));
            }

            IPeripheral peripheralToRemove = peripherals.First(p => p.GetType().Name == peripheralType);
            peripherals.Remove(peripheralToRemove);
            return peripheralToRemove;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine($" Components ({components.Count}):");
            foreach (var component in components)
            {
                sb.AppendLine("  " + component.ToString());
            }

            double average = 0;
            if (peripherals.Any())
            {
                average = peripherals.Average(p => p.OverallPerformance);
            }
            sb.AppendLine($" Peripherals ({peripherals.Count}); Average Overall Performance ({average:f2}):");
            foreach (var peripheral in peripherals)
            {
                sb.AppendLine("  " + peripheral.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
