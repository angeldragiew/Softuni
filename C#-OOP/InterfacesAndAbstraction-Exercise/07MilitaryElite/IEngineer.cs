using System;
using System.Collections.Generic;
using System.Text;

namespace _07MilitaryElite
{
    public interface IEngineer
    {
        IReadOnlyCollection<Repair> Repairs { get; }
    }
}
