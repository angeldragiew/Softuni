using Abstraction.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction
{
    public class Kitchen : ICookable,IOrderable, IRepairable
    {
        public void Cook()
        {
            Console.WriteLine("Making dish..");
        }

        public void Order()
        {
            Console.WriteLine("Ordering dish..");
        }

        public void Repair()
        {
            Console.WriteLine("Repairing..");
        }
    }
}
