using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type classType = typeof(StartUp);
            var methods = classType.GetMethods((BindingFlags)60);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(a => a.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);
                    foreach (AuthorAttribute attr in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {attr.Name}");
                    }
                }
            }
        }
    }
}
