using Logger.Contracts;
using Logger.Core.Factory;
using Logger.Core.Readers;
using Logger.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;
        private ILogger logger;

        public Engine(IReader reader, IAppenderFactory appenderFactory, ILayoutFactory layoutFactory)
        {
            this.reader = reader;
            this.appenderFactory = appenderFactory;
            this.layoutFactory = layoutFactory;
        }

        public void Run()
        {
            IAppender[] appenders = ReadAllAppenders();

            logger = new Logger(appenders);

            string input;
            while ((input = reader.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split("|");

                ReportLevel reportLevel = Enum.Parse<ReportLevel>(cmdArgs[0], true);
                string dateTime = cmdArgs[1];
                string message = cmdArgs[2];
                ProcessCommand(reportLevel, dateTime, message);
            }

            Console.WriteLine(logger);
        }

        private void ProcessCommand(ReportLevel reportLevel, string dateTime, string message)
        {
            switch (reportLevel)
            {
                case ReportLevel.Info:
                    logger.Info(dateTime, message);
                    break;
                case ReportLevel.Warning:
                    logger.Warning(dateTime, message);
                    break;
                case ReportLevel.Error:
                    logger.Error(dateTime, message);
                    break;
                case ReportLevel.Critical:
                    logger.Critical(dateTime, message);
                    break;
                case ReportLevel.Fatal:
                    logger.Fatal(dateTime, message);
                    break;
                default:
                    throw new ArgumentException("Invalid ReportLevel");
            }
        }

        private IAppender[] ReadAllAppenders()
        {
            int n = int.Parse(Console.ReadLine());
            IAppender[] appenders = new IAppender[n];

            for (int i = 0; i < n; i++)
            {
                string[] appenderInfo = Console.ReadLine().Split();
                string appenderType = appenderInfo[0];
                string layoutType = appenderInfo[1];
                string reportLevel = appenderInfo.Length == 3 ?
                    reportLevel = appenderInfo[2] :
                    reportLevel = ReportLevel.Info.ToString();

                ILayout layout = layoutFactory.CreateLayout(layoutType);
                IAppender appender = appenderFactory.CreateAppender(appenderType, layout, reportLevel);
                appenders[i] = appender;
            }

            return appenders;
        }
    }
}
