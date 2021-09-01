using Engine.Core.Interfaces;
using System.IO;

namespace Engine.Infrastructure.PolicySource
{
    public class FilePolicySource : IPolicySource
    {
        private readonly string Path;

        public FilePolicySource(string path)
        {
            Path = path;
        }

        public string GetPolicyFromSource()
        {
            return File.ReadAllText(Path);
        }
    }
}
