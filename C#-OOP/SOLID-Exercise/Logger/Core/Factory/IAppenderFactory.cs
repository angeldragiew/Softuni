using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Core.Factory
{
    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout, string reportLevel);
    }
}
