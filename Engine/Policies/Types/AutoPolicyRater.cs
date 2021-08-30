using Engine.Context;
using Policies;
using System;

namespace Engine.Policies.Types
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(IRatingContext context) : base(context) { }

        public override void Rate(Policy policy)
        {
            Logger.Log("Rating AUTO policy...");
            Logger.Log("Validating policy.");

            if (String.IsNullOrEmpty(policy.Make))
            {
                Logger.Log("Auto policy must specify Make");
                return;
            }

            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    _context.UpdateRating(1000m);
                }
                _context.UpdateRating(900m);
            }
        }
    }
}
