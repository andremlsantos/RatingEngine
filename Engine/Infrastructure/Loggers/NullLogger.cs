using Engine.Core.Interfaces;

namespace Engine.Infrastructure.Loggers
{
    public class NullLogger : ILogger
    {
        public void Log(string message)
        {
        }
    }
}
