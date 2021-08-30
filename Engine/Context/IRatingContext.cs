using Engine.Logging;
using Engine.Policies.Types;
using Policies;

namespace Engine.Context
{
    public interface IRatingContext : ILogger
    {
        string LoadPolicyFromFile();
        string LoadPolicyFromURI(string uri);

        Policy GetPolicyFromJsonString(string policyJson);
        Policy GetPolicyFromXmlString(string policyXml);

        Rater CreateRaterForPolicy(Policy policy, IRatingContext context);

        RatingEngine Engine { get; set; }
    }
}
