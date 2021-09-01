using Engine.Core.Interfaces;
using Engine.Core.Model;
using System;

namespace Engine.Core.Raters
{
    public class RaterFactory : IRaterFactory
    {
        private readonly ILogger _logger;

        public RaterFactory(ILogger logger)
        {
            _logger = logger;
        }

        public Rater Create(Policy policy)
        {
            var className = $"Engine.Core.Raters.{policy.Type}PolicyRater";

            try
            {
                return (Rater)Activator.CreateInstance(Type.GetType(className),
                    new object[] { _logger });
            }
            catch
            {
                return new UnknownPolicyRater(_logger);
            }
        }
    }
}
