using Microsoft.Extensions.Logging;
using PSProject.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsProjectExtended.Loggers
{
    internal class LoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new HashLoggers(categoryName);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
