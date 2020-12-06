using ExampleSolid;
using System.Collections.Generic;

namespace ExampleSolid.Test
{
    public class FakeLogger : ILogger
    {
        public List<string> LoggedMessages { get; } = new List<string>();
        public void Log(string message)
        {
            LoggedMessages.Add(message);
        }
    }
}
