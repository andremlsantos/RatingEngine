using Engine.Core.Interfaces;

namespace Tests
{
    public class FakePolicySource : IPolicySource
    {
        public string PolicyString { get; set; } = "";

        public string GetPolicyFromSource()
        {
            return PolicyString;
        }
    }
}
