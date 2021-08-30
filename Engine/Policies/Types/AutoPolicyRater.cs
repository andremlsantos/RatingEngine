﻿using Engine.Policies.Updater;
using Policies;
using System;

namespace Engine.Policies.Types
{
    public class AutoPolicyRater : Rater
    {
        public AutoPolicyRater(IRatingUpdater ratingUpdater) : base(ratingUpdater) { }

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
                    _ratingUpdater.UpdateRating(1000m);
                }
                _ratingUpdater.UpdateRating(900m);
            }
        }
    }
}
