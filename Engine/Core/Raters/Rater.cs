using Engine.Core.Interfaces;
using Engine.Core.Model;

namespace Engine.Core.Raters
{
    public abstract class Rater
    {
        public ILogger Logger { get; set; }

        protected decimal DefaultValue = 0m;

        public Rater(ILogger logger)
        {
            Logger = logger;
        }

        public abstract decimal Rate(Policy policy);
    }
}
