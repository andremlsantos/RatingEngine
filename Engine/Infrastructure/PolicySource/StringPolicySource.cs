using Engine.Core.Interfaces;

namespace Engine.Infrastructure.PolicySource
{
    public class StringPolicySource : IPolicySource
    {
        private readonly string Policy;

        public StringPolicySource(string policy)
        {
            Policy = policy;
        }

        public string GetPolicyFromSource()
        {
            return Policy;
        }
    }
}
