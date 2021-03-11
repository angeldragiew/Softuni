using System;
using System.Collections.Generic;
using System.Text;

namespace _07MilitaryElite
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<Repair> Repairs { get; }
    }
}
