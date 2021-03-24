using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsToInvestigate)
        {
            Type type = Type.GetType(className);
            FieldInfo[] fields = type.GetFields((BindingFlags)60);

            Object classInstance = Activator.CreateInstance(type, new object[] { });

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {className}");
            foreach (var field in fields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().Trim();
        }
    }
}
