using Engine.Context;
using Policies;

namespace Engine.Policies.Types
{
    public class LandPolicyRater : Rater
    {
        public LandPolicyRater(IRatingContext context) : base(context) { }

        public override void Rate(Policy policy)
        {
            Logger.Log("Rating LAND policy...");
            Logger.Log("Validating policy.");

            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Logger.Log("Land policy must specify Bond Amount and Valuation.");
                return;
            }

            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                Logger.Log("Insufficient bond amount.");
                return;
            }

            _context.UpdateRating(policy.BondAmount * 0.05m);
        }
    }
}