using Engine.Logging;
using Engine.Policies.Updater;
using Logging;
using Policies;

namespace Engine.Policies.Types
{
    public abstract class Rater
    {
        protected readonly IRatingUpdater _ratingUpdater;
        public ILogger Logger { get; set; } = new ConsoleLogger();

        public Rater(IRatingUpdater ratingUpdater)
        {
            _ratingUpdater = ratingUpdater;
        }

        public abstract void Rate(Policy policy);
    }
}
