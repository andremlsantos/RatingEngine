using Engine;
using Engine.Persistence;
using Engine.Policies.Factory;
using Engine.Serializer;
using Logging;

namespace MakeRatings
{
    static class Program
    {
        public static ConsoleLogger Logger { get; } = new ConsoleLogger();

        static void Main(string[] args)
        {
            Logger.Log("Ardalis Insurance Rating System Starting...");

            var logger = new ConsoleLogger();
            var engine = new RatingEngine(
                logger,
                new FilePolicySource(),
                new JsonPolicySerializer(),
                new RaterFactory(logger));

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
