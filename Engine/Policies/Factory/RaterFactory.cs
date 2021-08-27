using Engine.Policies.Types;
using Policies;

namespace Engine.Policies.Factory
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine engine)
        {
            return policy.Type switch
            {
                PolicyType.Life => new LifePolicyRater(engine, engine.Logger),
                PolicyType.Land => new LandPolicyRater(engine, engine.Logger),
                PolicyType.Auto => new AutoPolicyRater(engine, engine.Logger),
                PolicyType.Flood => new FloodPolicyRater(engine, engine.Logger),
                _ => new UnknownPolicyRater(engine, engine.Logger),
            };
        }
    }
}
