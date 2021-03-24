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

        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);

            FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();
            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in privateMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in publicMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }
            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] methods = classType.GetMethods((BindingFlags)60);
            StringBuilder sb = new StringBuilder();
            foreach (var method in methods)
            {
                if (method.Name.StartsWith("get"))
                {
                    sb.AppendLine($"{method.Name} will return {method.ReturnType}");
                }
                else if (method.Name.StartsWith("set"))
                {
                    sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
