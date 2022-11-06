using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace db_cp.Logger
{
    public class FileLogger : ILogger
    {

        private string filePath;
        private static object _lock = new object();
        private readonly string _name;

        public FileLogger(string path, string name)
        {
            filePath = path;
            _name = name;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                lock (_lock)
                {
                    string fullFilePath = Path.Combine(filePath, DateTime.Now.ToString("yyyy-MM-dd") + "_log.txt");
                    var n = Environment.NewLine;
                    string exc = "";

                    if (exception != null) exc = n + exception.GetType() + ": " + exception.Message + n + exception.StackTrace + n;
                    File.AppendAllText(fullFilePath,
                        logLevel.ToString() +
                        $": {_name}\n     " +
                        DateTime.Now.ToString() +
                        " " +
                        formatter(state, exception) + n + exc);
                }
            }
        }
    }
}