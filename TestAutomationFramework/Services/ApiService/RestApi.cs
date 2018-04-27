using JsonConfig;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TestAutomationFramework.Services.ApiService
{
    public class RestApi
    {
        //public IRestResponse SendRestApiRequest(string requestCmd)
        //{
        //    return SendRestApiRequest(requestCmd, new Dictionary<string, Object> { });
        //}

        //public IRestResponse SendRestApiRequest(string requestCmd, Dictionary<string, Object> paramPairs)
        //{
        //    //Dynamically create request object using predefined models by model name
        //    var modelName = SnakeCaseToCamelCase(requestCmd + "_request");
        //    var objectByModel = Activator.CreateInstance(Type.GetType("TestAutomationFramework.Services.ApiService." + modelName));
        //    var type = objectByModel.GetType();

        //    //Populate request fields
        //    PropertyInfo[] properties = type.GetProperties();
        //    foreach (PropertyInfo property in properties)
        //    {
        //        PropertyInfo currentProperty = type.GetProperty(property.Name);

        //        //try to set property from dictionary
        //        if (paramPairs.ContainsKey(currentProperty.Name))
        //        {
        //            currentProperty.SetValue(objectByModel, paramPairs[currentProperty.Name], null);
        //        }
        //        //try to set property from global settings
        //        else if ((Config.Global.api_settings).ContainsKey(currentProperty.Name))
        //        {
        //            currentProperty.SetValue(objectByModel, (Config.Global.api_settings)[currentProperty.Name], null);
        //        }
        //        //try to set property from requests
        //        else if ((Config.Global).ContainsKey(requestCmd))
        //        {
        //            currentProperty.SetValue(objectByModel, (Config.Global)[requestCmd][currentProperty.Name], null);
        //        }
        //    }

        //    //Send request and return result
        //    var client = new RestClient(Config.Global.environment.api_address + GetUrlPath4RestApi(requestCmd));
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("Cache-Control", "no-cache");
        //    request.AddHeader("Content-Type", "application/json");
        //    request.AddJsonBody(objectByModel);

        //    return client.Execute(request);
        //}

        public Object generateApiRequest(string requestCmd)
        {
            return generateApiRequest(requestCmd, new Dictionary<string, Object> { });
        }

        public Object generateApiRequest(string requestCmd, Dictionary<string, Object> paramPairs)
        {
            //Dynamically create request object using predefined models by model name
            var modelName = SnakeCaseToCamelCase(requestCmd);
            var objectByModel = Activator.CreateInstance(Type.GetType("TestAutomationFramework.Services.ApiService." + modelName));
            var type = objectByModel.GetType();

            //Populate request fields
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                PropertyInfo currentProperty = type.GetProperty(property.Name);

                if (currentProperty.PropertyType.Namespace.Equals("TestAutomationFramework.Services.ApiService"))
                {
                    currentProperty.SetValue(objectByModel, generateApiRequest(currentProperty.PropertyType.Name), null);
                    //SendRestApiRequest(currentProperty.PropertyType.Name);
                }
                
                //try to set property from dictionary
                else if (paramPairs.ContainsKey(currentProperty.Name))
                {
                    Console.WriteLine("Section 1");
                    currentProperty.SetValue(objectByModel, paramPairs[currentProperty.Name], null);
                }
                //try to set property from global settings
                else if ((Config.Global.api_settings).ContainsKey(currentProperty.Name))
                {
                    Console.WriteLine("Section 2");
                    currentProperty.SetValue(objectByModel, (Config.Global.api_settings)[currentProperty.Name], null);
                }
                //try to set property from requests
                else if ((Config.Global).ContainsKey(requestCmd))
                {
                    currentProperty.SetValue(objectByModel, (Config.Global)[requestCmd][currentProperty.Name], null);
                }
            }

            return objectByModel;

        }

        private static string SnakeCaseToCamelCase(string snakeCase)
        {
            return snakeCase.Split(new[] { "_" },
                StringSplitOptions.RemoveEmptyEntries).Select(s => char.ToUpperInvariant(s[0]) +
                s.Substring(1, s.Length - 1)).Aggregate(string.Empty, (s1, s2) => s1 + s2);
        }

        private Method GetMethodType4RestApi(string restApi)
        {
            return Method.POST;
        }

        private string GetUrlPath4RestApi(string restApi)
        {
            switch (restApi)
            {
                case "add_unit":
                case "check_device":
                case "get_account_units":
                case "get_car_models":
                case "get_reset_pin":
                case "get_server_info":
                case "get_timezones":
                case "logout":
                case "pair_device":
                case "register_pushes":
                case "reset_ownership":
                    return "box_pin";
                case "add_account_unit":
                case "add_car":
                case "delete_account_unit":
                case "delete_car":
                case "delete_program_signup_info":
                case "get_history":
                case "get_info":
                case "get_notifications":
                case "get_plot":
                case "get_program_signup_info":
                case "get_schedule":
                case "get_share_pin":
                case "get_state":
                case "get_utilitybill_url":
                case "select_car":
                case "set_charging_time":
                case "set_garage":
                case "set_info":
                case "set_limit":
                case "set_notifications":
                case "set_override":
                case "set_program_signup_info":
                case "set_schedule":
                case "share_device":
                case "update_car":
                    return "box_api_secure";
                default:
                    throw new ArgumentException("Unable to get path for: ", restApi);
            }
        }
    }
}