using EncodingFormat;
using Engine.Policies.Factory;
using Logging;
using Persistence;

namespace Engine
{
    public class RatingEngine
    {
        private const string Path = "";
        public ConsoleLogger Logger { get; } = new ConsoleLogger();
        public FilePolicySource Source { get; } = new FilePolicySource();
        public JsonPolicySerializer Serializer { get; } = new JsonPolicySerializer();
        public decimal Rating { get; set; }

        public void Rate()
        {
            Logger.Log("Starting rate.");
            Logger.Log("Loading policy.");

            var json = Source.GetPolicyFromSource(Path);
            var policy = Serializer.GetPolicyFromJsonString(json);
            var factory = new RaterReflectionFactory();
            var rater = factory.Create(policy, this);

            rater.Rate(policy);

            Logger.Log("Rating completed.");
        }
    }
}
