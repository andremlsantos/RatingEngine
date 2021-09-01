using Engine.Core.Interfaces;
using Engine.Core.Model;
using System;

namespace Engine.Core.Raters
{
    public class LifePolicyRater : Rater
    {
        public LifePolicyRater(ILogger logger) : base(logger) { }

        public override decimal Rate(Policy policy)
        {
            Logger.Log("Rating LIFE policy...");
            Logger.Log("Validating policy.");

            if (policy.DateOfBirth == DateTime.MinValue)
            {
                Logger.Log("Life policy must include Date of Birth.");
                return DefaultValue;
            }

            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                Logger.Log("Centenarians are not eligible for coverage.");
                return DefaultValue;
            }

            if (policy.Amount == 0)
            {
                Logger.Log("Life policy must include an Amount.");
                return DefaultValue;
            }

            var age = DateTime.Today.Year - policy.DateOfBirth.Year;
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }

            var baseRate = policy.Amount * age / 200;
            if (policy.IsSmoker)
            {
                return baseRate * 2;
            }

            return baseRate;
        }
    }
}
