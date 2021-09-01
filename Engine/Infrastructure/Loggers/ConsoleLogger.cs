using Engine.Core.Interfaces;
using System;

namespace Engine.Infrastructure.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
