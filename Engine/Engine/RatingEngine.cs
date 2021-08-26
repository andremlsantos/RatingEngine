using EncodingFormat;
using Engine.Policies.Rater;
using Logging;
using Persistence;
using Policies;

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

            switch (policy.Type)
            {
                case PolicyType.Auto:
                    var rater = new AutoPolicyRater(this, Logger);
                    rater.Rate(policy);

                    break;
                case PolicyType.Land:
                    var rater2 = new LandPolicyRater(this, Logger);
                    rater2.Rate(policy);

                    break;
                case PolicyType.Life:
                    var rater3 = new LifePolicyRater(this, Logger);
                    rater3.Rate(policy);

                    break;
                default:
                    Logger.Log("Unknown policy type");
                    break;
            }

            Logger.Log("Rating completed.");
        }
    }
}
