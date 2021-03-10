using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface IPerson : IIdentifiable, IBirthable
    {
        string Name { get; }
        int Age { get; }
    }
}
