using Logger.Contracts;
using Logger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders
{
    public abstract class Appender : IAppender
    {
        protected ILayout Layout { get; set; }
        public ReportLevel ReportLevel { get; set; }
        public Appender(ILayout layout)
        {
            Layout = layout;
        }
        protected int MessagesAppended { get; set; }
        public abstract void Append(string datetime, ReportLevel reportLevel, string message);

        protected bool IsReportLevelAppropriate(ReportLevel reportLevel)
        {
            return reportLevel >= this.ReportLevel;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {nameof(Layout)}, Report level: {ReportLevel}, Messages appended: {MessagesAppended}";
        }
    }
}
