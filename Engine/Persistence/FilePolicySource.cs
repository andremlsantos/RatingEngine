using System.IO;

namespace Engine.Persistence
{
    public class FilePolicySource
    {
        private const string Path = "";

        public string GetPolicyFromSource()
        {
            return File.ReadAllText(Path);
        }
    }
}
