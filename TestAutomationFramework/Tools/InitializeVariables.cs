using System;

namespace TestAutomationFramework.Tools
{
    public static class InitializeVariables
    {
        public static string GetFromEnvironment(string variable)
        {
            string _variable = null;
            try
            {
                _variable = Environment.GetEnvironmentVariable(variable);
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to get enviroment variable: " + variable);
            }
            if (null == _variable || _variable.Equals(""))
            {
                switch (variable)
                {
                    case "apiHost":
                        _variable = "http://emwjuicebox.cloudapp.net/";
                        Console.WriteLine("Set value to default: " + _variable);
                        break;
                    case "udpHost":
                        _variable = "emwjuicebox.cloudapp.net";
                        Console.WriteLine("Set value to default: " + _variable);
                        break;
                    case "webHost":
                        _variable = "https://dashboard.emotorwerks.com/";
                        Console.WriteLine("Set value to default: " + _variable);
                        break;
                    default:
                        Console.WriteLine("Unable to get default value: " + variable);
                        break;
                }
            }
            return _variable;
        }
    }
}
