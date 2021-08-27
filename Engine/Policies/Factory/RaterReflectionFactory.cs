using Engine.Policies.Types;
using Policies;
using System;

namespace Engine.Policies.Factory
{
    public class RaterReflectionFactory
    {
        public Rater Create(Policy policy, RatingEngine engine)
        {
            var className = $"Engine.Policies.Types.{ policy.Type}PolicyRater";

            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType(className),
                    new Object[] { engine, engine.Logger });
            }
            catch
            {
                return new UnknownPolicyRater(engine, engine.Logger);
            }
        }
    }
}
