using Logger.Contracts;
using Logger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string datetime, ReportLevel reportLevel, string message)
        {
            if (IsReportLevelAppropriate(reportLevel))
            {
                string text = string.Format(Layout.Template, datetime, reportLevel, message);
                Console.WriteLine(text);
                MessagesAppended++;
                Console.WriteLine();
            }
        }
    }
}
