using Logger.Contracts;
using Logger.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Core.Factory
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            ILayout layout = null;
            switch (type)
            {
                case nameof(SimpleLayout):
                    layout = new SimpleLayout();
                    break;
                case nameof(XmlLayout):
                    layout = new XmlLayout();
                    break;
                default:
                    throw new ArgumentException("Invalid layout");
            }
            return layout;
        }
    }
}
