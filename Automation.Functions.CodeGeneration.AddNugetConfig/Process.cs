using Automation.Functions.Abstractions;
using System;
using System.IO;

namespace Automation.Functions.CodeGeneration.AddNugetConfig
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
                if (!File.Exists(path))
                {
                    var key = Guid.NewGuid().ToString();
                    state[key] = @"<?xml version=""1.0"" encoding=""utf-8""?>
<configuration>
  <packageSources>
    <add key=""NuGet v3 feed"" value=""https://api.nuget.org/v3/index.json"" />
  </packageSources>
</configuration>";
                    state = new WriteFile.Process().Function(state, new { key = key, path = path });
                    state[key] = null;
                }
                return state;
            };
    }
}
