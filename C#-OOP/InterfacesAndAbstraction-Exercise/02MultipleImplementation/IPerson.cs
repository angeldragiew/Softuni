using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface IIdentifiable
    {
        string Name { get; }
        int Age { get; }
    }
}
