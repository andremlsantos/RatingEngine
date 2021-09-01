using Engine.Context;
using Engine.Logging;

namespace Engine
{
    public class RatingEngine
    {
        private readonly ILogger _logger;

        public IRatingContext Context { get; set; } = new DefaultRatingContext();
        public decimal Rating { get; set; }

        public RatingEngine(ILogger logger)
        {
            _logger = logger;
            Context.Engine = this;
        }

        public void Rate()
        {
            _logger.Log("Starting rate.");
            _logger.Log("Loading policy.");

            var policyJson = Context.LoadPolicyFromFile();
            var policy = Context.GetPolicyFromJsonString(policyJson);
            var rater = Context.CreateRaterForPolicy(policy, Context);

            rater.Rate(policy);

            _logger.Log("Rating completed.");
        }
    }
}
