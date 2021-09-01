using Engine.Core.Interfaces;
using Engine.Core.Model;

namespace Engine.Core.Raters
{
    public class UnknownPolicyRater : Rater
    {
        public UnknownPolicyRater(ILogger logger) : base(logger) { }

        public override decimal Rate(Policy policy)
        {
            Logger.Log("Unknown policy type");

            return DefaultValue;
        }
    }
}
