﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
namespace PSProject.Loggers
{
     class HashLoggers : ILogger
    {
        private readonly System.Collections.Concurrent.ConcurrentDictionary<int, string> _logMessage;
        private readonly string _name;

        public HashLoggers(string name)
        {
            _name = name;
            _logMessage = new ConcurrentDictionary<int, string>(); 
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true ;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = formatter(state, exception);
            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red; break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow; break;
                default:
                    Console.ForegroundColor = ConsoleColor.White; break;

            }

            Console.WriteLine("- Logger -");
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"[{logLevel}]");
            messageToBeLogged.AppendFormat(" [{0}]", _name);
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($"{formatter(state, exception)}");
            Console.WriteLine("-Logger-");
            Console.ResetColor();
            _logMessage[eventId.Id] = message;
        }
    }


}
