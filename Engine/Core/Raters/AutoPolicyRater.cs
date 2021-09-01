using Engine.Core.Interfaces;
using Engine.Core.Model;
using System;

namespace Engine.Core.Raters
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(ILogger logger) : base(logger) { }

        public override decimal Rate(Policy policy)
        {
            Logger.Log("Rating AUTO policy...");
            Logger.Log("Validating policy.");

            if (String.IsNullOrEmpty(policy.Make))
            {
                Logger.Log("Auto policy must specify Make");
                return DefaultValue;
            }

            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    return 1000m;
                }
                return 900m;
            }

            return DefaultValue;
        }
    }
}
