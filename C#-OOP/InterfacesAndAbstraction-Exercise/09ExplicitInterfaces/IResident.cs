﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _09ExplicitInterfaces
{
    public interface IResident
    {
        string Name { get; }
        string Country { get; }
        string GetName();
    }
}
