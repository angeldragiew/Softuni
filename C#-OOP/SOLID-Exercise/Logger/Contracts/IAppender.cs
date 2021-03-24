using Logger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Contracts
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }
        void Append(string datetime, ReportLevel reportLevel, string message);
    }
}
