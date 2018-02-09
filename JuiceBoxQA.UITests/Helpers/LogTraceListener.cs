using System;
using TechTalk.SpecFlow.Tracing;

namespace JuiceBoxQA.UITests.Helpers
{
    public class LogTraceListener : ITraceListener
    {
        static public string LastGherkinMessage;

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