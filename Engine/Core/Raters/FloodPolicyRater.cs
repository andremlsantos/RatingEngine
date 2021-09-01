using Engine.Core.Interfaces;
using Engine.Core.Model;

namespace Engine.Core.Raters
{
    public class FloodPolicyRater : Rater
    {
        public FloodPolicyRater(ILogger logger) : base(logger) { }

        public override decimal Rate(Policy policy)
        {
            Logger.Log("Rating FLOOD policy...");
            Logger.Log("Validating policy.");

            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                Logger.Log("Flood policy must specify Bond Amount and Valuation.");
                return DefaultValue;
            }

            if (policy.ElevationAboveSeaLevelFeet <= 0)
            {
                Logger.Log("Flood policy is not available for elevations at or below sea level.");
                return DefaultValue;
            }

            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                Logger.Log("Insufficient bond amount.");
                return DefaultValue;
            }

            decimal multiple = 1.0m;
            if (policy.ElevationAboveSeaLevelFeet < 100)
            {
                multiple = 2.0m;
            }
            else if (policy.ElevationAboveSeaLevelFeet < 500)
            {
                multiple = 1.5m;
            }
            else if (policy.ElevationAboveSeaLevelFeet < 1000)
            {
                multiple = 1.1m;
            }

            return policy.BondAmount * 0.05m * multiple;
        }
    }
}
