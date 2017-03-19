using Automation.Functions.Abstractions;
using System;

namespace Automation.Functions.FileFindAndReplace
{
    public class Process : IFunction
    {
        public Func<dynamic, dynamic, dynamic> Function { get; }
            = (state, process) =>
            {
                var key = Guid.NewGuid().ToString();
                state = new ReadFile.Process().Function(state, new { key = key, path = process["path"] });
                state = new Replace.Process().Function(state, new { key = key, oldText = process["oldText"], newText = process["newText"] });
                state = new WriteFile.Process().Function(state, new { key = key, path = process["path"] });
                state[key] = null;
                return state;
            };
    }
}
