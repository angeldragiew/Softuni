using Logger.Contracts;
using Logger.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger.Appenders
{
    public class FileAppender : Appender
    {
        private ILogFile logfile;
        public FileAppender(ILayout layout, ILogFile logfile)
            : base(layout)
        {
            this.logfile = logfile;
        }

        public override void Append(string datetime, ReportLevel reportLevel, string message)
        {
            if (IsReportLevelAppropriate(reportLevel))
            {
                string text = string.Format(Layout.Template, datetime, reportLevel, message) + Environment.NewLine;
                logfile.Write(text);
                MessagesAppended++;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}, File size: {logfile.Size}";
        }
    }
}
