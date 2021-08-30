using Engine.Context;

namespace Engine
{
    public class RatingEngine
    {
        public IRatingContext Context { get; set; } = new DefaultRatingContext();
        public decimal Rating { get; set; }

        public RatingEngine()
        {
            Context.Engine = this;
        }

        public void Rate()
        {
            Context.Log("Starting rate.");
            Context.Log("Loading policy.");

            var policyJson = Context.LoadPolicyFromFile();
            var policy = Context.GetPolicyFromJsonString(policyJson);
            var rater = Context.CreateRaterForPolicy(policy, Context);

            rater.Rate(policy);

            Context.Log("Rating completed.");
        }
    }
}
