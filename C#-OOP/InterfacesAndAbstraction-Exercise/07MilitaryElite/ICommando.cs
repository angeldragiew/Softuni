using System;
using System.Collections.Generic;
using System.Text;

namespace _07MilitaryElite
{
    public interface ICommando
    {
        IReadOnlyCollection<Mission> Missions { get; }
    }
}
