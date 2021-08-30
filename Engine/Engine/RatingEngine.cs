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
            Context.Logger.Log("Starting rate.");
            Context.Logger.Log("Loading policy.");

            var policyJson = Context.LoadPolicyFromFile();
            var policy = Context.GetPolicyFromJsonString(policyJson);
            var rater = Context.CreateRaterForPolicy(policy, Context);

            rater.Rate(policy);

            Context.Logger.Log("Rating completed.");
        }
    }
}
