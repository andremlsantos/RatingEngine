using Engine.Core.Model;
using Engine.Core.Raters;

namespace Engine.Core.Interfaces
{
    public interface IRaterFactory
    {
        public Rater Create(Policy policy);
    }
}
