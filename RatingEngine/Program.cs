using Engine;
using Logging;

namespace MakeRatings
{
    static class Program
    {
        public static ConsoleLogger Logger { get; } = new ConsoleLogger();

        static void Main(string[] args)
        {
            Logger.Log("Ardalis Insurance Rating System Starting...");

            var engine = new RatingEngine();
            engine.Rate();

            if (engine.Rating > 0)
            {
                Logger.Log($"Rating: {engine.Rating}");
            }
            else
            {
                Logger.Log("No rating produced.");
            }
        }
    }
}
