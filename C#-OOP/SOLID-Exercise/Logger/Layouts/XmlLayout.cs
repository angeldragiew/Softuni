using Logger.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Template => "<log>" + Environment.NewLine
            + "  <date>{0}</date>" + Environment.NewLine
            + "  <level>{1}</level>" + Environment.NewLine
            + "  <message>{2}</message>" + Environment.NewLine
            + "</log>";
    }
}
