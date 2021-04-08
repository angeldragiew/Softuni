using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }


        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer computer = computers.FirstOrDefault(c => c.Id == computerId);
            if(computer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComputerId));
            }

            if (components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            IComponent component = null;
            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidComponentType));
            }

            components.Add(component);
            computer.AddComponent(component);

            return String.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComputerId));
            }

            IComputer computer = null;
            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidComputerType));
            }

            computers.Add(computer);
            return String.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = computers.FirstOrDefault(c => c.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComputerId));
            }

            if (peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheralId));
            }

            IPeripheral peripheral = null;
            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidPeripheralType));
            }

            computer.AddPeripheral(peripheral);
            peripherals.Add(peripheral);

            return String.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            List<IComputer> bestForBudget = computers.Where(c => c.Price <= budget).ToList();

            if (bestForBudget.Any() == false)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            bestForBudget = bestForBudget.OrderByDescending(c => c.OverallPerformance).ToList();
            IComputer computer = bestForBudget[0];

            computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer computer = computers.FirstOrDefault(c => c.Id == id);
            if (computer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComputerId));
            }
            computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = computers.FirstOrDefault(c => c.Id == id);
            if (computer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComputerId));
            }
            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = computers.FirstOrDefault(c => c.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComputerId));
            }
            IComponent component = computer.RemoveComponent(componentType);
            components.Remove(component);

            return String.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = computers.FirstOrDefault(c => c.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComputerId));
            }
            IPeripheral peripheral = computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);

            return String.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }
    }
}
