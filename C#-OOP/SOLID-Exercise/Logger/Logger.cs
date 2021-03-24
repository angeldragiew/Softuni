using Logger.Contracts;
using Logger.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    public class Logger : ILogger
    {
        private readonly List<IAppender> appenders;
        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders.ToList();
        }

        public void Error(string dateTime, string message)
        {
            AppendToAppenders(dateTime, ReportLevel.Error, message);
        }

        public void Info(string dateTime, string message)
        {
            AppendToAppenders(dateTime, ReportLevel.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            AppendToAppenders(dateTime, ReportLevel.Warning, message);
        }

        public void Critical(string dateTime, string message)
        {
            AppendToAppenders(dateTime, ReportLevel.Critical, message);
        }

        public void Fatal(string dateTime, string message)
        {
            AppendToAppenders(dateTime, ReportLevel.Fatal, message);
        }

        private void AppendToAppenders(string dateTime, ReportLevel reportLevel, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(dateTime, reportLevel, message);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var appender in appenders)
            {
                sb.AppendLine(appender.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
