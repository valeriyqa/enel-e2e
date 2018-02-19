#region

using System;
using TechTalk.SpecFlow.Tracing;

#endregion

namespace UITests.Helpers
{
    public class LogTraceListener : ITraceListener
    {
        public static string LastGherkinMessage;

        public void WriteTestOutput(string message)
        {
            LastGherkinMessage = message;

            Console.WriteLine(message);
        }

        public void WriteToolOutput(string message)
        {
            Console.WriteLine(message);
        }
    }
}