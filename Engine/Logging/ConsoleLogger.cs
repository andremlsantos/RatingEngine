using System;

namespace Logging
{
    public class ConsoleLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
