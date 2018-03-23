using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.IO;
using RestSharp;
using System;

namespace TestAutomationFramework.Services
{
    public class RestApi
    {
        public IRestResponse GetRestApiResponse(string restApi)
        {
            string url = "http://emwjuicebox.cloudapp.net/box_pin/";
            string tokenv = "197ec3927726422b970d88f57dac2a43";
            string unit_idv = "0100000199990047469017016501";
            string device_idv = "linker";
            string account_tokenv = "4dd4e4c7-2304-4a05-88a6-3ffabc900660";

            return GetRestApiResponse(restApi, url, tokenv, unit_idv, device_idv, account_tokenv);
        }

        public IRestResponse GetRestApiResponse(string restApi, string url, string tokenv, string unit_idv, string device_idv, string account_tokenv)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cache-Control", "no-cache");
            request.AddHeader("Content-Type", "application/json");

            switch (restApi)
            {
                case "get_timezones":
                case "get_server_info":
                case "get_car_models":
                    request.AddJsonBody(new { cmd = restApi });
                    break;
                case "check_device":
                    request.AddJsonBody(new { cmd = restApi, ID = unit_idv });
                    break;
                case "get_account_units": //
                    request.AddJsonBody(new { cmd = restApi, account_token = account_tokenv, device_id = device_idv });
                    break;
                case "get_state":
                case "get_history": //
                case "get_schedule": //
                case "get_info":
                case "get_notifications":
                case "get_utilitybill_url": //
                case "get_program_signup_info": //
                    request.AddJsonBody(new { cmd = restApi, account_token = account_tokenv, token = tokenv, device_id = device_idv });
                    break;
                default:
                    throw new ArgumentException("Unknown Rest API request: ", restApi);
            }

            return client.Execute(request);
        }

        public JObject responseToJObject(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<JObject>(response.Content);
        }

        public JSchema GetJSchema(string fileName)
        {
            if (Path.GetExtension(fileName).Equals(""))
            {
                fileName = fileName + ".json";
            }

            string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Services\ApiService\Schemas\", fileName);

            JSchema schema;
            try
            {
                schema = JSchema.Parse(File.ReadAllText(pathFile));

            }
            catch (Exception)
            {
                Console.WriteLine("Unable to get schema from file: " + fileName);
                return null;
            }
            return schema;
        }
    }
}