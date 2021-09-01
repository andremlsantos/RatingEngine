using Engine.Core.Model;

namespace Engine.Core.Interfaces
{
    public interface IPolicySerializer
    {
        public Policy GetPolicyFromString(string json);
    }
}
