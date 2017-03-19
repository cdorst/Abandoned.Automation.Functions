using Automation.Functions.Abstractions;
using System;

namespace Automation.Functions.Replace
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
                var oldText = (string)process["oldText"];
                if (string.IsNullOrWhiteSpace(oldText))
                {
                    throw new ArgumentNullException("oldText",
                        "The oldText property must be defined for the current ReadFile process. This is the text to find and replace.");
                }
                var newText = (string)process["newText"];
                state[key] = ((string)state[key])?.Replace(oldText, newText);
                return state;
            };
    }
}
