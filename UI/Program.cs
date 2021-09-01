using Engine.Core;
using Engine.Core.Model;
using Engine.Core.Raters;
using Engine.Infrastructure.Loggers;
using Engine.Infrastructure.PolicySource;
using Engine.Infrastructure.Serializers;

namespace UI
{
    static class Program
    {
        static void Main(string[] args)
        {
            //var policy = GetAutoPolicy();
            var policy = GetFloodPolicy();

            var logger = new ConsoleLogger();
            var engine = new RatingEngine(logger,
                new StringPolicySource(policy.ToString()),
                new JsonPolicySerializer(),
                new RaterFactory(logger));

            engine.Rate();

            if (engine.Rating > 0)
            {
                logger.Log($"Rating: {engine.Rating}");
            }
            else
            {
                logger.Log("No rating produced.");
            }
        }

        private static Policy GetFloodPolicy()
        {
            return new Policy()
            {
                Type = PolicyType.Flood,
                BondAmount = 1000000,
                Valuation = 1100000,
                ElevationAboveSeaLevelFeet = 1001
            };
        }

        private static Policy GetAutoPolicy()
        {
            return new Policy()
            {
                Type = PolicyType.Auto,
                Make = "BMW",
                Deductible = 250m
            };
        }


    }
}
