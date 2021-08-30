using Engine.Policies.Updater;
using Policies;

namespace Engine.Policies.Types
{
    public class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(IRatingUpdater ratingUpdater) : base(ratingUpdater) { }

        public override void Rate(Policy policy)
        {
            Logger.Log("Unknown policy type");
        }
    }
}
