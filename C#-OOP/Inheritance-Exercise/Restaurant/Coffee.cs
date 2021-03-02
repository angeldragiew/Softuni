using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const decimal price = 5M;
        private const double millilitres = 50;
        public Coffee(string name, double caffeine) 
            : base(name, price, millilitres)
        {
            Caffeine = caffeine;
        }
        public double Caffeine  { get; set; }
    }
}
