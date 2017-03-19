using Automation.Functions.Abstractions;
using System;
using System.IO;

namespace Automation.Functions.CodeGeneration.AddNugetFeed
{
    public class Process : IFunction
    {
        public Func<dynamic, dynamic, dynamic> Function { get; }
            = (state, process) =>
            {
                var path = (string)process["path"];
                if (!path.EndsWith("nuget.config"))
                {
                    path = Path.Combine(path, "nuget.config");
                }
                state = new AddNugetConfig.Process().Function(state, new { path = path });
                state = new FileFindAndReplace.Process().Function(state, new { path = path, oldText = "</packageSources>", newText = $"<add key=\"{(string)process["name"]}\" value=\"{(string)process["value"]}\" /></packageSources>" });
                return state;
            };
    }
}
