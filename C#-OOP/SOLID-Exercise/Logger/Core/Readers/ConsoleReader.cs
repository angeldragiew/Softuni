﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Core.Readers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
