using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using RestSharp;
using System;
using System.IO;

namespace TestAutomationFramework.Services
{
    public class RestApi
    {
        public IRestResponse GetRestApiResponse(string restApi)
        {
            string uriHost = Hooks.globalVariables["apiAddress"].ToString();
            string uriPath = GetUriPath4RestApi(restApi);
            Method methodType = GetMethodType4RestApi(restApi);
            JObject request = GetJRequest(restApi);
            return GetRestApiResponse(restApi, uriHost, uriPath, methodType, request);
        }

        public IRestResponse GetRestApiResponse(string restApi, string uriHost, string uriPath, Method methodType, JObject request)
        {
            var _client = new RestClient(uriHost);
            var _request = new RestRequest(uriPath, methodType);
            _request.AddHeader("Cache-Control", "no-cache");
            _request.AddHeader("Content-Type", "application/json");
            _request.AddParameter("undefined", request, ParameterType.RequestBody);
            return _client.Execute(_request);
        }

        public JObject responseToJObject(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<JObject>(response.Content);
        }

        public JSchema GetJSchema(string restApi)
        {
            if (Path.GetExtension(restApi).Equals(""))
            {
                restApi = restApi + ".json";
            }

            string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Services\ApiService\Schemas\", restApi);

            JSchema schema;
            try
            {
                schema = JSchema.Parse(File.ReadAllText(pathFile));

            }
            catch (Exception)
            {
                Console.WriteLine("Unable to get schema from file: " + restApi);
                return null;
            }
            return schema;
        }

        private JObject GetJRequest(string restApi)
        {
            if (Path.GetExtension(restApi).Equals(""))
            {
                restApi = restApi + ".json";
            }

            string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Services\ApiService\Requests\prod\", restApi);

            JObject request;
            try
            {
                request = JObject.Parse(File.ReadAllText(pathFile));

            }
            catch (Exception)
            {
                Console.WriteLine("Unable to get request from file: " + restApi);
                return null;
            }
            return request;
        }

        private Method GetMethodType4RestApi(string restApi)
        {
            return Method.POST;
        }

        private string GetUriPath4RestApi(string restApi)
        {
            switch (restApi)
            {
                case "check_device":
                case "get_account_units":
                case "get_car_models":
                case "get_server_info":
                case "get_timezones":
                    return "box_pin";
                case "get_history":
                case "get_info":
                case "get_notifications":
                case "get_program_signup_info":
                case "get_schedule":
                case "get_state":
                case "get_utilitybill_url":
                    return "box_api_secure";
                default:
                    throw new ArgumentException("Unable to get path for: ", restApi);
            }
        }
    }
}