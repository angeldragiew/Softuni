using System;
using System.Collections.Generic;
using System.Text;

namespace _09ExplicitInterfaces
{
    public interface IPerson
    {
        string Name { get; }
        int Age { get; }
        string GetName();
    }
}
