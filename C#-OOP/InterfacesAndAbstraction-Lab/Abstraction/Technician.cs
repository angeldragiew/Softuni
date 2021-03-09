using Abstraction.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction
{
    public class Technician
    {
        public Technician(IRepairable kitchen)
        {
            Kitchen = kitchen;
        }
        public IRepairable Kitchen { get; set; }
    }
}
