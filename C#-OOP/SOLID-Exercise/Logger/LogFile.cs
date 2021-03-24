using Logger.Contracts;
using Logger.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Logger
{
    public class LogFile : ILogFile
    {
        private const string path = "../../../log.txt";
        public int Size => File.ReadAllText(path).Where(ch => char.IsLetter(ch)).Sum(s => s);

        public void Write(string text)
        {
            File.AppendAllText(path, text);
        }
    }
}
