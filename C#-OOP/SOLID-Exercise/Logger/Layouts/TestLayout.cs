using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layouts
{
    public class TestLayout : ILayout
    {
        public string Template => "{0} *** {1} *** {2}";
    }
}
