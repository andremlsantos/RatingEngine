using Engine.Core;
using Engine.Core.Model;
using Engine.Core.Raters;
using Engine.Infrastructure.Serializers;
using Newtonsoft.Json;
using Xunit;

namespace Tests
{
    public class RatingEngineRate
    {
        private RatingEngine _engine = null;
        private FakeLogger _logger;
        private FakePolicySource _policySource;
        private JsonPolicySerializer _policySerializer;

        public RatingEngineRate()
        {
            _logger = new FakeLogger();
            _policySource = new FakePolicySource();
            _policySerializer = new JsonPolicySerializer();

            _engine = new RatingEngine(_logger,
                _policySource,
                _policySerializer,
                new RaterFactory(_logger));
        }

        [Fact]
        public void ReturnsRatingOf10000For200000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 200000
            };

            _policySource.PolicyString = JsonConvert.SerializeObject(policy); ;
            _engine.Rate();

            Assert.Equal(10000, _engine.Rating);
        }

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };

            _policySource.PolicyString = JsonConvert.SerializeObject(policy);
            _engine.Rate();

            Assert.Equal(0, _engine.Rating);
        }

        [Fact]
        public void LogsStartingLoadingAndCompleting()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            _policySource.PolicyString = JsonConvert.SerializeObject(policy);
            _engine.Rate();

            Assert.Contains(_logger.LoggedMessages, m => m == "Starting rate.");
            Assert.Contains(_logger.LoggedMessages, m => m == "Loading policy.");
            Assert.Contains(_logger.LoggedMessages, m => m == "Rating completed.");
        }
    }
}
