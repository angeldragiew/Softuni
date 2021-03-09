using Abstraction.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction
{
    class NotAKitchen : ICookable, IOrderable, IRepairable
    {
        public void Cook()
        {
            Console.WriteLine("I can't cook");
        }

        public void Order()
        {
            Console.WriteLine("I can't order");
        }

        public void Repair()
        {
            Console.WriteLine("I can't repair");
        }
    }
}
