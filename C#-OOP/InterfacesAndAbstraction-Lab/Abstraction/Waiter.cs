using Abstraction.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction
{
    public class Waiter
    {
        public Waiter(IOrderable kitchen)
        {
            Kitchen = kitchen;
        }
        public IOrderable Kitchen { get; set; }
    }
}
