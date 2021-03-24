using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Core.Factory
{
    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}
