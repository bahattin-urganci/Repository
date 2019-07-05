using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace PawPos.Infrastructure
{
    public static class Constants
    {
        public static string AppPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
