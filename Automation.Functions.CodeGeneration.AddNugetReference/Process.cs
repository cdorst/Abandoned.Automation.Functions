using Automation.Functions.Abstractions;
using System;

namespace Automation.Functions.CodeGeneration.AddNugetReference
{
    public class Process : IFunction
    {
        public Func<dynamic, dynamic, dynamic> Function { get; }
            = (state, process) => new FileFindAndReplace.Process().Function(state, new
            {
                path = (string)process["csproj"],
                oldText = "</Project>",
                newText = $"<ItemGroup><PackageReference Include=\"{(string)process["package"]}\" Version=\"{(string)process["version"]}\" /></ItemGroup></Project>"
            });
    }
}
