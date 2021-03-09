using Abstraction.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction
{
    public class Chef
    {
        public Chef(ICookable kitchen)
        {
            Kitchen = kitchen;
        }
        public ICookable Kitchen { get; set; }
    }
}
