using Engine.Core.Interfaces;
using Engine.Core.Model;

namespace Engine.Core.Raters
{
    public class LandPolicyRater : Rater
    {
        public LandPolicyRater(ILogger logger) : base(logger) { }

        public override decimal Rate(Policy policy)
        {
            Logger.Log("Rating LAND policy...");
            Logger.Log("Validating policy.");

            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Logger.Log("Land policy must specify Bond Amount and Valuation.");
                return DefaultValue;
            }

            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                Logger.Log("Insufficient bond amount.");
                return DefaultValue;
            }

            return policy.BondAmount * 0.05m;
        }
    }
}