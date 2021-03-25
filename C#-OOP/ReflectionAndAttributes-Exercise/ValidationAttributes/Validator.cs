using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property
                    .GetCustomAttributes()
                    .Where(a => a is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();
                object value = property.GetValue(obj);
                foreach (var attr in attributes)
                {
                    bool isValid = attr.IsValid(value);
                    if (isValid == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
