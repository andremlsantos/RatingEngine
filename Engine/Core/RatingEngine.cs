using Engine.Core.Interfaces;

namespace Engine.Core
{
    public class RatingEngine
    {
        private readonly ILogger _logger;
        private readonly IPolicySource _policySource;
        private readonly IPolicySerializer _policySerializer;
        private readonly IRaterFactory _raterFactory;
        public decimal Rating { get; set; }

        public RatingEngine(ILogger logger,
            IPolicySource policySource,
            IPolicySerializer policySerializer,
            IRaterFactory raterFactory)
        {
            _logger = logger;
            _policySource = policySource;
            _policySerializer = policySerializer;
            _raterFactory = raterFactory;
        }

        public void Rate()
        {
            _logger.Log("Starting rate.");
            _logger.Log("Loading policy.");

            var policyJson = _policySource.GetPolicyFromSource();
            var policy = _policySerializer.GetPolicyFromString(policyJson);
            var rater = _raterFactory.Create(policy);

            Rating = rater.Rate(policy);

            _logger.Log("Rating completed.");
        }
    }
}
