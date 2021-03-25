using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandName)
        {
            var type = Assembly.GetEntryAssembly().GetTypes().FirstOrDefault(t => t.Name.StartsWith(commandName));

            if (type == null)
            {
                throw new ArgumentException($"{commandName} is invalid type");
            }
           
            return (ICommand)Activator.CreateInstance(type);
        }
    }
}
