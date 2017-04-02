using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.StaticReferences
{
    public static class PropertiesHelper
    {
        public static bool PublicInstancePropertiesEqual<T>(T self, T to) where T : class
        {
            if (self != null && to != null)
            {
                Type type = typeof(T);
                foreach (System.Reflection.PropertyInfo pi in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                {
                    if (!pi.IsDefined(typeof(SkipAttribute), false))
                    {
                        object selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                        object toValue = type.GetProperty(pi.Name).GetValue(to, null);

                        if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return self == to;
        }
    }
}
