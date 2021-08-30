using Engine.Context;
using Engine.Policies.Types;
using Policies;
using System;

namespace Engine.Policies.Factory
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, IRatingContext context)
        {
            var className = $"Engine.Policies.Types.{ policy.Type}PolicyRater";

            try
            {
                return (Rater)Activator.CreateInstance(Type.GetType(className), new object[] { context });
            }
            catch
            {
                return new UnknownPolicyRater(context);
            }
        }
    }
}
