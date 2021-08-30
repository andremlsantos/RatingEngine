using Engine.Context;
using Engine.Policies.Types;
using Engine.Policies.Updater;
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
                return (Rater)Activator.CreateInstance(Type.GetType(className), new object[] {
                    new RatingUpdater(context.Engine)
                });
            }
            catch
            {
                return new UnknownPolicyRater(new RatingUpdater(context.Engine));
            }
        }
    }
}
