using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Template.Shared.Extensions.Reflection
{
    public static class TypeExtension
    {
        public static Assembly GetAssembly(this Type type)
        {
            return type.GetTypeInfo().Assembly;
        }
    }
}
