using Logger.Appenders;
using Logger.Contracts;
using Logger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Core.Factory
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout, string reportLevel)
        {
            ReportLevel parsedReportLevel = Enum.Parse<ReportLevel>(reportLevel,true);
            IAppender appender = null;
            switch (type)
            {
                case nameof(ConsoleAppender):
                    appender = new ConsoleAppender(layout)
                    {
                        ReportLevel = parsedReportLevel
                    };
                    break;
                case nameof(FileAppender):
                    appender = new FileAppender(layout, new LogFile())
                    {
                        ReportLevel = parsedReportLevel
                    };
                    break;
                default:
                    throw new ArgumentException("Invalid appender");
            }

            return appender;
        }
    }
}
