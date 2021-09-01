using Engine.Core.Interfaces;
using Engine.Core.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Engine.Infrastructure.Serializers
{
    public class JsonPolicySerializer : IPolicySerializer
    {
        public Policy GetPolicyFromString(string policyString)
        {
            return JsonConvert.DeserializeObject<Policy>(policyString,
                new StringEnumConverter());
        }
    }
}
