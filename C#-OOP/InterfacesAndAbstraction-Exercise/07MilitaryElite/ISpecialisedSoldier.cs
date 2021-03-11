using System;
using System.Collections.Generic;
using System.Text;

namespace _07MilitaryElite
{
    public interface ISpecialisedSoldier : IPrivate
    {
        string Corps { get; }
    }
}
