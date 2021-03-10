using System;
using System.Collections.Generic;
using System.Text;

namespace _03Telephony
{
    public abstract class Phone : ICallable
    {
        public abstract void Call(string number);
    }
}
