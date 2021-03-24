using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Contracts
{
    public interface ILayout
    {
        public string Template { get; }
    }
}
