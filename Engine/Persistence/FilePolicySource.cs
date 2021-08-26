using System;
using System.IO;

namespace Persistence
{
    public class FilePolicySource
    {
        public string GetPolicyFromSource(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            return File.ReadAllText(path);
        }
    }
}
