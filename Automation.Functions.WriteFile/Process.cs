using Automation.Functions.Abstractions;
using System;
using System.IO;

namespace Automation.Functions.WriteFile
{
    public class Process : IFunction
    {
        public Func<dynamic, dynamic, dynamic> Function { get; }
            = (state, process) =>
            {
                var key = (string)process["key"];
                if (string.IsNullOrWhiteSpace(key))
                {
                    throw new ArgumentNullException("key",
                        "The key property must be defined for the current ReadFile process. This is the key used to save the file contents as string to the state object");
                }
                var path = (string)process["path"];
                if (string.IsNullOrWhiteSpace(path))
                {
                    throw new ArgumentNullException("path",
                        "The path property must be defined for the current ReadFile process. This is the path to the file to read.");
                }
                File.WriteAllText(path, (string)state[key]);
                return state;
            };
    }
}
