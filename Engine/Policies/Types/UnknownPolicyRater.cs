using Engine.Context;
using Policies;

namespace Engine.Policies.Types
{
    public class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(IRatingContext context) : base(context) { }

        public override void Rate(Policy policy)
        {
            _logger.Log("Unknown policy type");
        }
    }
}
