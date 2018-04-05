using System;
using System.Collections;
using System.IO;
using static TestAutomationFramework.Tools.LoadTableFromFile;

namespace TestAutomationFramework.Tools
{
    class InitializeVariables
    {
        public static string GetEnvironment(string variable)
        {
            //Set default environment here. Can be "alpha", "beta" or "prod".
            string defaultEnv = "alpha";
            try
            {
                string env = Environment.GetEnvironmentVariable(variable);
                switch (env)
                {
                    case "alpha":
                    case "beta":
                    case "prod":
                        return env;
                    default:
                        Console.WriteLine("Variable have illegal value: " + env);
                        Console.WriteLine("Set enviroment to default: " + defaultEnv);
                        return defaultEnv;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Unable to get variable: " + variable);
                Console.WriteLine("Set enviroment to default: " + defaultEnv);
                return defaultEnv;
            }
        }

        public static IDictionary LoadVariablesFromFile(string fileName, string sheetName, string useColumnAsKey)
        {
            string workEnvironment = GetEnvironment("environment");
            string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Resource\", fileName);
            return GetDictionary(LoadDataTable(pathFile, sheetName), useColumnAsKey, workEnvironment);
        }
    }
}
