using JsonConfig;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TestAutomationFramework.Services.ApiService
{
    public class RestApi
    {
        public static Object GetPropertyValue(Object source, string path)
        {
            string[] bits = path.Split('.');
            Type type = source.GetType(); // Or pass this in
            Object result = source;
            foreach (string bit in bits)
            {
                PropertyInfo prop = type.GetProperty(bit);
                type = prop.PropertyType;
                result = prop.GetValue(result, null);
            }
            return result;
        }

        public static IRestResponse SendApiRequest(Object apiRequestBody)
        {
            string requestCmd = apiRequestBody.GetType().GetProperty("cmd").GetValue(apiRequestBody, null).ToString();
            var client = new RestClient(Config.Global.env_api_address + GetUrlPath4RestApi(requestCmd));
            var request = new RestRequest(GetMethodType4RestApi(requestCmd));
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(apiRequestBody);
            return client.Execute(request);
        }

        public static Object GetApiRequest(string requestCmd)
        {
            return GetApiRequest(requestCmd, new Dictionary<string, Object> { });
        }

        public static Object GetApiRequest(string requestCmd, Dictionary<string, Object> paramPairs)
        {
            var pathToModelObjects = "TestAutomationFramework.Services.ApiService";
            var pathToRequests = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Services\ApiService\B2cRequests\");
            var modelName = SnakeCaseToCamelCase(requestCmd);
            var jObject = Activator.CreateInstance(Type.GetType(pathToModelObjects + "." + modelName));

            //Populate request with default data, from corresponding json file
            jObject = JsonConvert.DeserializeObject(File.ReadAllText(pathToRequests + requestCmd + ".json"), jObject.GetType());

            //Add data from system settings

            //foreach (dynamic property in Config.Global)
            //{
            //    try
            //    {
            //        jObject.GetType().GetProperty(property.Key).SetValue(jObject, property.Value);
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}



            //Add data from dictionary
            foreach (var item in paramPairs)
            {
                try
                {
                    jObject.GetType().GetProperty(item.Key).SetValue(jObject, item.Value);
                }
                catch (Exception)
                {
                }
            }

            return jObject;
        }

        public static Object ResponseToObject(string requestCmd, IRestResponse response)
        {
            var pathToModelObjects = "TestAutomationFramework.Services.ApiService";
            var pathToRequests = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Services\ApiService\B2cRequests\");
            var modelName = SnakeCaseToCamelCase(requestCmd + "Response");
            dynamic jObject;
            try
            {
                jObject = Activator.CreateInstance(Type.GetType(pathToModelObjects + "." + modelName));
            }
            catch (Exception)
            {
                jObject = Activator.CreateInstance(Type.GetType(pathToModelObjects + ".GeneralResponse"));
            }
            return JsonConvert.DeserializeObject(response.Content, jObject.GetType());
        }

        public static JSchema GetJSchema(string requestCmd)
        {
            if (Path.GetExtension(requestCmd).Equals(""))
            {
                requestCmd = requestCmd + ".json";
            }

            string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Services\ApiService\B2cSchemas\", requestCmd);

            JSchema schema;
            try
            {
                schema = JSchema.Parse(File.ReadAllText(pathFile));

            }
            catch (Exception)
            {
                Console.WriteLine("Unable to get schema from file: " + requestCmd);
                return null;
            }
            return schema;
        }

        public static Object ConvertTypeByName(string value)
        {
            if (value.ToLower().Equals("null"))
            {
                return null;
            }
            else if (bool.TryParse(value, out bool bResult))
            {
                return bResult;
            }
            else if (Int32.TryParse(value, out int iResult))
            {
                return iResult;
            }
            else if (double.TryParse(value, out double dResult))
            {
                return dResult;
            }
            else if (DateTime.TryParse(value, out DateTime dtResult))
            {
                return dtResult;
            }
            return value;
        }

        private static string SnakeCaseToCamelCase(string snakeCase)
        {
            return snakeCase.Split(new[] { "_" },
                StringSplitOptions.RemoveEmptyEntries).Select(s => char.ToUpperInvariant(s[0]) +
                s.Substring(1, s.Length - 1)).Aggregate(string.Empty, (s1, s2) => s1 + s2);
        }

        //This method will be useful, when we start use not only post method
        private static Method GetMethodType4RestApi(string requestCmd)
        {
            return Method.POST;
        }

        private static string GetUrlPath4RestApi(string requestCmd)
        {
            switch (requestCmd)
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
                    throw new ArgumentException("Unable to get path for: ", requestCmd);
            }
        }

        //For test purpose only
        private static void PrintAllProperties(Object objectName)
        {
            foreach (var prop in objectName.GetType().GetProperties())
            {
                Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(objectName, null));
            }
        }
    }
}