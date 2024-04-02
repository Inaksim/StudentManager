using Microsoft.Extensions.Logging;
using PsProjectExtended.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsProjectExtended.Helpers
{
    internal static class LoggerHelper
    {
        public static ILogger GetLogger(string categoryName)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new LoggerProvider());
            return loggerFactory.CreateLogger(categoryName);
        }
    }
}
