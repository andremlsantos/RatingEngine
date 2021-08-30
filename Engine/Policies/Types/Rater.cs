using Engine.Context;
using Engine.Logging;
using Logging;
using Policies;

namespace Engine.Policies.Types
{
    public abstract class Rater
    {
        protected readonly IRatingContext _context;
        protected ILogger Logger { get; set; } = new ConsoleLogger();

        public Rater(IRatingContext context)
        {
            _context = context;
        }

        public abstract void Rate(Policy policy);
    }
}
