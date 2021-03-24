using Logger.Appenders;
using Logger.Contracts;
using Logger.Core;
using Logger.Core.Factory;
using Logger.Core.Readers;
using Logger.Enums;
using Logger.Layouts;
using System;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            ILayoutFactory layoutFactory = new LayoutFactory();
            IAppenderFactory appenderFactory = new AppenderFactory();

            IEngine engine = new Engine(new ConsoleReader(), appenderFactory, layoutFactory);
            engine.Run();
        }
    }
}
