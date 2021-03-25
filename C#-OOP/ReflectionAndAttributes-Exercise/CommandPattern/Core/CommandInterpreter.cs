using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly CommandFactory commandFactory;
        public CommandInterpreter()
        {
            commandFactory = new CommandFactory();
        }
        public string Read(string args)
        {
            string[] data = args.Split();
            string commandName = data[0];
            string[] commandArgs = data.Skip(1).ToArray();

            ICommand command = commandFactory.CreateCommand(commandName);

            return command.Execute(commandArgs);
        }
    }
}
