using System;

namespace Trains.Infrastructure
{
    public class LoggerStandardOut : ILogger
    {
        public void debug(string message) => Console.WriteLine($"DEBUG|{DateTime.Now}|{message}");

        public void error(string message) => Console.WriteLine($"ERROR|{DateTime.Now}|{message}");

        public void fatal(string message) => Console.WriteLine($"FATAL|{DateTime.Now}|{message}");

        public void info(string message) => Console.WriteLine($"INFO|{DateTime.Now}|{message}");

        public void trace(string message) => Console.WriteLine($"TRACE|{DateTime.Now}|{message}");

        public void warning(string message) => Console.WriteLine($"WARNING|{DateTime.Now}|{message}");
    }
}