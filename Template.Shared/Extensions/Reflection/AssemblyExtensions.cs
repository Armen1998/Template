using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Template.Shared.Extensions.Reflection
{
    public static class AssemblyExtensions
    {
        public static string GetDirectoryPathOrNull(this Assembly assembly)
        {
            var location = assembly.Location;
            if (location == null)
            {
                return null;
            }

            var directory = new FileInfo(location).Directory;
            if (directory == null)
            {
                return null;
            }

            return directory.FullName;
        }
    }
}
